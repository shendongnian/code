    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [DefaultProperty("Text")]
    public class TextArea: WebControl, IPostBackDataHandler, IEditableTextControl
    {
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Textarea; }
        }
        public bool CausesValidation
        {
            get
            {
                if (ViewState["CausesValidation"] == null)
                    return false;
                return (bool)ViewState["CausesValidation"];
            }
            set
            {
                ViewState["CausesValidation"] = value;
            }
        }
        public string ValidationGroup
        {
            get
            {
                return (string)ViewState["ValidationGroup"] ?? "";
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        }
        public string Text
        {
            get
            {
                return (string)ViewState["Text"] ?? "";
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
        public bool ReadOnly
        {
            get
            {
                if (ViewState["Readonly"] == null)
                    return false;
                return (bool)ViewState["Readonly"];
            }
            set
            {
                ViewState["Readonly"] = value;
            }
        }
        public int Rows
        {
            get
            {
                if (ViewState["Rows"] == null)
                    return 0;
                return (int)ViewState["Rows"];
            }
            set
            {
                ViewState["Rows"] = value;
            }
        }
        public int Columns
        {
            get
            {
                if (ViewState["Columns"] == null)
                    return 0;
                return (int)ViewState["Columns"];
            }
            set
            {
                ViewState["Columns"] = value;
            }
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            if (Enabled && !IsEnabled)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            if (ReadOnly)
                writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, "readonly");
            if (Rows != 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Rows, Rows.ToString(NumberFormatInfo.InvariantInfo));
            if (Columns != 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Cols, Columns.ToString(NumberFormatInfo.InvariantInfo));
            base.AddAttributesToRender(writer);
        }
        public override void RenderControl(HtmlTextWriter writer)
        {
            RenderBeginTag(writer);
            writer.WriteEncodedText(Text);
            RenderEndTag(writer);
        }
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            var strPostBack = postCollection[postDataKey];
            if (ReadOnly || Text.Equals(strPostBack, StringComparison.Ordinal))
                return false;
            Text = strPostBack;
            return true;
        }
        public void RaisePostDataChangedEvent()
        {
            if (!Page.IsPostBackEventControlRegistered)
            {
                Page.AutoPostBackControl = this;
                if (CausesValidation)
                    Page.Validate(ValidationGroup);
            }
            TextChanged(this, EventArgs.Empty);
        }
        public event EventHandler TextChanged = delegate { };
    }
