    public class UCDialogBox : WebControl, INamingContainer
    {
        private ITemplate htmlPlaceHolder = null;
    
        [
        Browsable(false),
        DefaultValue(null),
        Description("Add your html contorls"),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual ITemplate HtmlPlaceHolder
        {
            get
            {
                return htmlPlaceHolder;
            }
            set
            {
                htmlPlaceHolder = value;
            }
        }
    
        protected override void Render(HtmlTextWriter output)
        {
            HtmlGenericControl placeholder = new HtmlGenericControl();
    
            htmlPlaceHolder.InstantiateIn(placeholder);
    
            var html = placeholder.Controls[1] as System.Web.UI.HtmlControls.HtmlGenericControl;
    
            var result = html.InnerHtml.Replace("\r", "").Replace("\n", "").Trim();
    
            output.Write(result);
        }
    }
