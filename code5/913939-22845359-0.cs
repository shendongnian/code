    namespace YourNamespace
    {
        public class PrintTags
        {
            public void Process(RenderLayoutArgs args)
            {
                //put here validation you may require
    
                var head = WebUtil.FindControlOfType(Sitecore.Context.Page.Page, typeof(System.Web.UI.HtmlControls.HtmlHead));
    
                if (head != null)
                {
                    //add any content in the head
                    head.Controls.Add(new Literal(" CONTENT "));
                }
                else
                {
                    //make sure to not break the app instead just log the error.
                    Sitecore.Diagnostics.Log.Error("Error - The HEAD element must be runat=server", this);
                }
            }
    	}
    }
