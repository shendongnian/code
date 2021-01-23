    public class ItemEventArgs : EventArgs
    {
        #region Properties
        public int Index { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        #endregion Properties
    }
    public class UnorderedItem
    {
        #region Constructors
        public UnorderedItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
        #endregion Constructors
        #region Properties
        public string Text { get; set; }
        public string Value { get; set; }
        #endregion Properties
    }
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:UnorderedList runat=server></{0}:UnorderedList>")]
    public class UnorderedList : WebControl, IPostBackEventHandler//, IScriptControl
    {
        #region Fields
        private ScriptManager scriptManager;
        #endregion Fields
        #region Constructors
        public UnorderedList()
        {
            Items = new List<UnorderedItem>();
        }
        #endregion Constructors
        #region Events
        public event EventHandler<ItemEventArgs> ItemClick;
        #endregion Events
        #region Properties
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [DefaultValue("")]
        public string ItemAltCssClass { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [DefaultValue("")]
        public string ItemCssClass { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        public List<UnorderedItem> Items { get; set; }
        [Bindable(true)]
        [DefaultValue("")]
        [Category("Client Events")]
        [Localizable(true)]
        public string OnClientItemClick { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [DefaultValue("")]
        public int SelectedIndex { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [DefaultValue("")]
        public string SelectedItemCssClass { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [DefaultValue("")]
        public string SelectedValue { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text { get; set; }
        #endregion Properties
        #region Methods
        public void ClearSelection()
        {
            Text = null;
            SelectedValue = null;
            SelectedIndex = -1;
        }
        //public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        //{
        //    return new ScriptReference[] { };
        //}
        //public IEnumerable<ScriptReference> GetScriptReferences()
        //{
        //    return new ScriptDescriptor[] { };
        //}
        public void RaisePostBackEvent(string eventArgument)
        {
            ItemEventArgs args = new ItemEventArgs();
            args.Index = Convert.ToInt32(eventArgument);
            UnorderedItem item = Items[args.Index];
            args.Text = item.Text;
            args.Value = item.Value;
            SelectedValue = args.Value;
            SelectedIndex = args.Index;
            Text = args.Text;
            if (ItemClick != null)
            {
                ItemClick(this, args);
            }
        }
        protected virtual void OnItemClick(ItemEventArgs e)
        {
            EventHandler<ItemEventArgs> handler = ItemClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            //if (!DesignMode)
            //{
            //    scriptManager = ScriptManager.GetCurrent(Page);
            //    if (scriptManager == null)
            //    {
            //        throw new HttpException("A scriptmanager control must exist on the current page.");
            //    }
            //    scriptManager.RegisterScriptControl(this);
            //}
            base.OnPreRender(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //if (!this.DesignMode)
            //{
            //    scriptManager.RegisterScriptDescriptors(this);
            //}
            var itemCssClass = false;
            var itemAltCssClass = false;
            if (!string.IsNullOrEmpty(ItemCssClass))
            {
                itemCssClass = true;
            }
            if (!string.IsNullOrEmpty(ItemAltCssClass))
            {
                itemAltCssClass = true;
            }
            writer.WriteBeginTag("ul");
            if (!string.IsNullOrEmpty(CssClass))
            {
                writer.WriteAttribute("class", CssClass);
            }
            if (!string.IsNullOrEmpty(AccessKey))
            {
                writer.WriteAttribute("AccessKey", AccessKey);
            }
            if (Style != null && !string.IsNullOrEmpty(Style.Value))
            {
                writer.WriteAttribute("style", Style.Value);
            }
            writer.WriteAttribute("value", string.IsNullOrEmpty(SelectedValue) ? Items[0].Value : SelectedValue);
            writer.WriteAttribute("index", SelectedIndex.ToString());
            writer.WriteAttribute("id", this.ClientID);
            writer.Write(HtmlTextWriter.TagRightChar);
            var itemClass = string.Empty;
            var prefix = string.Concat(ClientID, "_Item");
            UnorderedItem item;
            for (var i = 0; i < Items.Count; i++)
            {
                itemClass = string.Empty;
                item = Items[i];
                writer.WriteBeginTag("li");
                writer.WriteAttribute("index", i.ToString());
                writer.WriteAttribute("value", item.Value);
                writer.WriteAttribute("onclick", String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", "SetSelectedValue(this, '", item.Text, "','", item.Value, "',", i, ");", OnClientItemClick ?? string.Empty, Page.ClientScript.GetPostBackEventReference(this, i.ToString())));
                if (i % 2 == 0)
                {
                    if (itemCssClass)
                    {
                        itemClass = ItemCssClass;
                    }
                }
                else
                {
                    if (itemAltCssClass)
                    {
                        itemClass = ItemAltCssClass;
                    }
                }
                if (SelectedIndex == i)
                {
                    itemClass = String.Format("{0}{1}{2}", itemClass, " ", SelectedItemCssClass).Trim();
                }
                if (itemClass != string.Empty)
                {
                    writer.WriteAttribute("class", ItemCssClass);
                }
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(item.Text);
                writer.WriteEndTag("li");
            }
            writer.WriteEndTag("ul");
            //base.Render(writer);
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
        }
        #endregion Methods
    }
