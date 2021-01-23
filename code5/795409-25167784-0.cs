        private DropDownList ddlMainXslTemplate;
        private ContentQuery webPart;
        public ContentQueryToolPart()
        {
            this.Title = "more props";
        }
        public override void ApplyChanges()
        {
            webPart.MainXslTemplate = (MainXslTemplateEnum)Enum.Parse(typeof(MainXslTemplateEnum), ddlMainXslTemplate.SelectedItem.Text);
        }
        
        protected override void OnInit(EventArgs e)
        {
            webPart = (ContentQuery)this.ParentToolPane.SelectedWebPart;
            base.OnInit(e);
        }
        protected override void CreateChildControls()
        {
            Label label = new Label();
            label.Text = "main xsl";
            this.Controls.Add(label);
            ddlMainXslTemplate = new DropDownList();
            ddlMainXslTemplate.DataSource = Enum.GetNames(typeof(MainXslTemplateEnum));
            ddlMainXslTemplate.DataBind();
            if (string.IsNullOrEmpty(webPart.MainXslTemplate.ToString()) == false)
            {
                ddlMainXslTemplate.SelectedValue = webPart.MainXslTemplate.ToString();
            }
            this.Controls.Add(ddlMainXslTemplate);
            //btw a custom UC can go here
        }
        protected override void RenderToolPart(System.Web.UI.HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, "ContentQueryToolPart");
            output.RenderBeginTag(HtmlTextWriterTag.Div);
            base.RenderToolPart(output);
            output.RenderEndTag();
            //this is mainly for css 
        }
    }
