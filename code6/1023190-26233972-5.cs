    public partial class _Default : Page
    {
       
        protected override void Render(HtmlTextWriter writer)
        {
            var html = GetInnerHtml();
             //Use html string
            Response.Write(html);
        }
      
        string GetInnerHtml()
        {
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(sw))
                {
                    RenderChildren(htmlWriter);
                    return sw.ToString();
                }
            }
        }
    }
