    // the area builder class
    public class AreaBuilder: IHtmlString
    {
        private string name;
        private string caption;
        private MvcHtmlString content; // to allow the use to add html content
    
        public AreaBuilder Name(string name)
        {
            this.name=name;
            return this;
        }
    
        public AreaBuilder Content(Func<object, HelperResult> html)
        {
            var detail=html.Invoke(null);
            this.content=MvcHtmlString.Create(detail.ToHtmlString());
            return this;
        }
    
        public string ToHtmlString()
        {
             var html=new StringBuilder();
             html.AppendFormat(@"<div id=""{0}"" class=""area"">",name);
             html.AppendFormat(@"<div class=""area-caption"">{0}</div>",caption);
             html.AppendFormat(@"<div class=""area-content"">{0}</div>",content.ToHtmlString());
             html.Append("</div>");
             return html.ToString();
        }
    }
