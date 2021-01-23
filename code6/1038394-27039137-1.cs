    /// <summary>
    /// Own implementation of "ParseControl". Returns XHTML (default) or HTML.
    /// Custom controls from "Web.config" are supported (TODO: User controls and imports on Page are NOT).
    /// </summary>
    private class OwnParseControlEngine {
    
        public class ParseException : System.Exception {
            public ParseException(HtmlNode e)
                : base("Unknown ASP.NET server-tag \"" + e.OriginalName + "\".") {
            }
        }
    
        private static readonly String _systemWebNamespace;
        private static readonly String _systemWebAssembly;
    
        private static readonly Dictionary<String, LinkedList<TagPrefixInfo>> _controlsTagPrefixInfos = new Dictionary<String, LinkedList<TagPrefixInfo>>();  // Key is tag-prefix in lowercase
    
        private class Factory {
            public delegate Control CreateDel(HtmlNode e);
            private readonly CreateDel _del;
            public Boolean DropWhiteSpaceLiterals { get; private set; }
            public Factory(CreateDel del, Boolean dropWhiteSpaceLiterals = false) {
                this._del = del;
                this.DropWhiteSpaceLiterals = dropWhiteSpaceLiterals;
            }
            public Control Create(HtmlNode e) {
                return this._del.Invoke(e);
            }
        }
        private static readonly Dictionary<String, Factory> _factories = new Dictionary<String, Factory>();  // Must be locked. Key is tag-name in lowercase.
    
        static OwnParseControlEngine() {
            // We cache the results to speed things up. "Panel" is only used to get assembly info.
            _systemWebNamespace = typeof(Panel).Namespace;
            _systemWebAssembly = typeof(Panel).Assembly.FullName;
            var section = (PagesSection)WebConfigurationManager.OpenWebConfiguration("/").GetSection("system.web/pages");
            foreach (TagPrefixInfo info in section.Controls) {
                LinkedList<TagPrefixInfo> l;
                if (!_controlsTagPrefixInfos.TryGetValue(info.TagPrefix, out l)) {
                    l = new LinkedList<TagPrefixInfo>();
                    _controlsTagPrefixInfos.Add(info.TagPrefix.ToLower(), l);
                }
                l.AddLast(info);
            }
            // Add HTML control types
            _factories.Add("span", new Factory((e) => { return new HtmlGenericControl(e.OriginalName); }));
            _factories.Add("div", new Factory((e) => { return new HtmlGenericControl(e.OriginalName); }));
            _factories.Add("body", new Factory((e) => { return new HtmlGenericControl(e.OriginalName); }));
            _factories.Add("font", new Factory((e) => { return new HtmlGenericControl(e.OriginalName); }));
            _factories.Add("a", new Factory((e) => { return new HtmlAnchor(); }));
            _factories.Add("button", new Factory((e) => { return new HtmlButton(); }));
            _factories.Add("form", new Factory((e) => { return new HtmlForm(); }));
            _factories.Add("input", new Factory((e) => {
                switch (e.Attributes["type"].Value) {
                    case "button": return new HtmlInputButton();
                    case "checkbox": return new HtmlInputCheckBox();
                    case "file": return new HtmlInputFile();
                    case "hidden": return new HtmlInputHidden();
                    case "image": return new HtmlInputImage();
                    case "radio": return new HtmlInputRadioButton();
                    case "text": return new HtmlInputText();
                    case "password": return new HtmlInputPassword();
                    case "reset": return new HtmlInputReset();
                    case "submit": return new HtmlInputSubmit();
                }
                throw new ParseException(e);
            }));
            _factories.Add("select", new Factory((e) => { return new HtmlSelect(); }));
            _factories.Add("table", new Factory((e) => { return new HtmlTable(); }, true));  // Adding literals not allowed
            _factories.Add("tr", new Factory((e) => { return new HtmlTableRow(); }, true));  // Adding literals not allowed
            _factories.Add("td", new Factory((e) => { return new HtmlTableCell(); }));
            _factories.Add("textarea", new Factory((e) => { return new HtmlTextArea(); }));
            _factories.Add("link", new Factory((e) => { return new HtmlLink(); }));
            _factories.Add("meta", new Factory((e) => { return new HtmlMeta(); }));
            _factories.Add("title", new Factory((e) => { return new HtmlTitle(); }));
            _factories.Add("img", new Factory((e) => { return new HtmlImage(); }));
        }
    
        private static void ApplyHtmlControlAttributes(HtmlControl c, HtmlNode e) {
            foreach (HtmlAttribute a in e.Attributes) {
                if (a.Name == "id")
                    c.ID = a.Value;
                else if (a.Name != "runat")
                    c.Attributes[a.OriginalName] = HttpUtility.HtmlDecode(a.Value);
            }
        }
    
        private static void ApplyControlAttributes(Control c, HtmlNode e) {
            if (c is WebControl && e.Attributes["style"] != null) {
                String style = HttpUtility.HtmlDecode(e.Attributes["style"].Value);
                foreach (String s in style.Split(new Char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    ((WebControl)c).Style[s.Substring(0, s.IndexOf(':'))] = s.Substring(s.IndexOf(':') + 1);
            }
            foreach (PropertyInfo p in c.GetType().GetProperties()) {
                if (p.CanRead && p.CanWrite && e.Attributes[p.Name] != null) {
                    try {
                        Object v = null;
                        if (p.PropertyType.IsEnum)
                            v = Enum.Parse(p.PropertyType, e.Attributes[p.Name].Value);
                        else if (p.PropertyType == typeof(String))
                            v = e.Attributes[p.Name].Value;
                        else if (p.PropertyType == typeof(Boolean))
                            v = Boolean.Parse(e.Attributes[p.Name].Value);
                        else if (p.PropertyType == typeof(Int32))
                            v = Int32.Parse(e.Attributes[p.Name].Value);
                        else if (p.PropertyType == typeof(Unit))
                            v = Unit.Parse(e.Attributes[p.Name].Value);
                        // TODO: More types?
                        if (v != null)
                            p.SetValue(c, v, null);
                    }
                    catch {
                    }
                }
            }
        }
    
        private static Control CreateServerControl(HtmlNode e, out Boolean dropWhiteSpaceLiterals) {                    
            Factory cf;
            lock (_factories) {
                _factories.TryGetValue(e.Name, out cf);
            }
            if (cf == null) {
                Int32 pos = e.Name.IndexOf(':');
                if (pos != -1) {
                    String tagPrefix = e.Name.Substring(0, pos).ToLower();
                    String name = e.Name.Substring(pos + 1);
                    Type t = null;
                    // Try "System.Web" (default assembly)
                    if (tagPrefix == "asp")
                        t = Type.GetType(String.Format("{0}.{1}, {2}", _systemWebNamespace, name, _systemWebAssembly), false, true);  // "Namespace.ClassName, Assembly"
                    if (t == null) {
                        // Try controls specified in "web.config"
                        LinkedList<TagPrefixInfo> l;
                        if (_controlsTagPrefixInfos.TryGetValue(tagPrefix, out l)) {
                            foreach (var info in l) {
                                // Custom controls
                                t = Type.GetType(String.Format("{0}.{1}, {2}", info.Namespace, name, info.Assembly), false, true);  // "Namespace.ClassName, Assembly"
                                if (t != null)
                                    break;
                                // TODO: User controls with tag.TagName, tag.Source
                            }
                        }
                    }
                    if (t != null) {
                        cf = new Factory((e2) => { return (Control)Activator.CreateInstance(t); });
                        lock (_factories) {
                            _factories[e.Name] = cf;  // "Replace" instead of "Add", because another thread might have already added it since the lock above
                        }
                    }
                }
            }
            if (cf == null)
                throw new ParseException(e);
            var c = cf.Create(e);
            if (c is HtmlControl)
                ApplyHtmlControlAttributes((HtmlControl)c, e);
            else
                ApplyControlAttributes(c, e);
            dropWhiteSpaceLiterals = cf.DropWhiteSpaceLiterals;
            return c;
        }
    
        private static void ParseChildren(Control parentC, HtmlNode currE, Boolean xhtml = true, Boolean dropWhiteSpaceLiterals = false) {
            foreach (HtmlNode childE in currE.ChildNodes) {
                Control newC = null, closeTag = null;
                Boolean newDropWhiteSpaceLiterals = false;
                if (childE.Attributes["runat"] != null && childE.Attributes["runat"].Value.ToLower() == "server")  // Server control
                    newC = CreateServerControl(childE, out newDropWhiteSpaceLiterals);
                else {  // Literal control
                    switch (childE.Name) {
                        case "#text":
                            if (!dropWhiteSpaceLiterals || childE.InnerText.Trim().Length != 0)
                                newC = new LiteralControl(childE.InnerText);
                            break;
                        default:
                            String s = String.Format("<{0}", childE.OriginalName);
                            foreach (HtmlAttribute a in childE.Attributes)
                                s += String.Format(" {0}=\"{1}\"", a.OriginalName, a.Value);
                            s += ">";
                            switch (childE.Name) {
                                // List of void elements taken from http://www.programmerinterview.com/index.php/html5/void-elements-html5/
                                case "area": case "base": case "br": case "col": case "command": case "embed": case "hr": case "img": case "input":
                                case "keygen": case "link": case "meta": case "param": case "source": case "track": case "wbr":
                                    if (xhtml)
                                        s = s.Substring(0, s.Length - 1) + "/>";
                                    newC = new LiteralControl(s);
                                    break;
                                default:
                                    newC = new PlaceHolder();  // Used as a wrapper to allow child-controls
                                    newC.Controls.Add(new LiteralControl(s));
                                    closeTag = new LiteralControl(String.Format("</{0}>", childE.OriginalName));
                                    break;
                            }
                            break;
                    }
                }
                if (newC != null) {
                    parentC.Controls.Add(newC);
                    ParseChildren(newC, childE, xhtml, newDropWhiteSpaceLiterals);
                    if (closeTag != null)
                        newC.Controls.Add(closeTag);
                }
            }
        }
    
        private OwnParseControlEngine() {
        }
    
        /// <summary>
        /// Parses the given HTML document and returns a Control.
        /// Throws "ParseException" on error (TODO: Maybe others too).
        /// </summary>
        public static Control Parse(HtmlDocument doc) {
            var c = new Control();
            ParseChildren(c, doc.DocumentNode, false);
            return c;
        }
    }
