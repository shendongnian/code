        public class HtmlXsltContext : XsltContext
        {
            public HtmlXsltContext()
                : base(new NameTable())
            {
            }
            public override int CompareDocument(string baseUri, string nextbaseUri)
            {
                throw new NotImplementedException();
            }
            public override bool PreserveWhitespace(XPathNavigator node)
            {
                throw new NotImplementedException();
            }
            protected virtual IXsltContextFunction CreateHtmlXsltFunction(string prefix, string name, XPathResultType[] ArgTypes)
            {
                return HtmlXsltFunction.GetBuiltIn(this, prefix, name, ArgTypes);
            }
            public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
            {
                return CreateHtmlXsltFunction(prefix, name, ArgTypes);
            }
            public override IXsltContextVariable ResolveVariable(string prefix, string name)
            {
                throw new NotImplementedException();
            }
            public override bool Whitespace
            {
                get { return true; }
            }
        }
        public abstract class HtmlXsltFunction : IXsltContextFunction
        {
            protected HtmlXsltFunction(HtmlXsltContext context, string prefix, string name, XPathResultType[] argTypes)
            {
                Context = context;
                Prefix = prefix;
                Name = name;
                ArgTypes = argTypes;
            }
            public HtmlXsltContext Context { get; private set; }
            public string Prefix { get; private set; }
            public string Name { get; private set; }
            public XPathResultType[] ArgTypes { get; private set; }
            public virtual int Maxargs
            {
                get { return Minargs; }
            }
            public virtual int Minargs
            {
                get { return 1; }
            }
            public virtual XPathResultType ReturnType
            {
                get { return XPathResultType.String; }
            }
            public abstract object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext);
            public static IXsltContextFunction GetBuiltIn(HtmlXsltContext context, string prefix, string name, XPathResultType[] argTypes)
            {
                if (name == "regex-is-match")
                    return new RegexIsMatch(context, name);
                // TODO: create other functions here
                return null;
            }
            public static string ConvertToString(object argument, bool outer, string separator)
            {
                if (argument == null)
                    return null;
                string s = argument as string;
                if (s != null)
                    return s;
                XPathNodeIterator it = argument as XPathNodeIterator;
                if (it != null)
                {
                    if (!it.MoveNext())
                        return null;
                    StringBuilder sb = new StringBuilder();
                    do
                    {
                        HtmlNodeNavigator n = it.Current as HtmlNodeNavigator;
                        if (n != null && n.CurrentNode != null)
                        {
                            if (sb.Length > 0 && separator != null)
                            {
                                sb.Append(separator);
                            }
                            sb.Append(outer ? n.CurrentNode.OuterHtml : n.CurrentNode.InnerHtml);
                        }
                    }
                    while (it.MoveNext());
                    return sb.ToString();
                }
                IEnumerable enumerable = argument as IEnumerable;
                if (enumerable != null)
                {
                    StringBuilder sb = null;
                    foreach (object arg in enumerable)
                    {
                        if (sb == null)
                        {
                            sb = new StringBuilder();
                        }
                        if (sb.Length > 0 && separator != null)
                        {
                            sb.Append(separator);
                        }
                        string s2 = ConvertToString(arg, outer, separator);
                        if (s2 != null)
                        {
                            sb.Append(s2);
                        }
                    }
                    return sb != null ? sb.ToString() : null;
                }
                return string.Format("{0}", argument);
            }
            public class RegexIsMatch : HtmlXsltFunction
            {
                public RegexIsMatch(HtmlXsltContext context, string name)
                    : base(context, null, name, null)
                {
                }
                public override XPathResultType ReturnType { get { return XPathResultType.Boolean; } }
                public override int Minargs { get { return 2; } }
                public override object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
                {
                    if (args.Length < 2)
                        return false;
                    return Regex.IsMatch(ConvertToString(args[0], false, null), ConvertToString(args[1], false, null));
                }
            }
        }
