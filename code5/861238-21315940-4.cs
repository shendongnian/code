    using System;
    using System.Web.UI.Adapters;
    namespace SampleWebApplication
    {
        public class PageTitleAdapter : PageAdapter
        {
            protected override void OnPreRender(EventArgs e)
            {
                base.OnPreRender(e);
                if (this.Page.Title != null)
        		{
                   this.Page.Title = "Somesite - " + this.Page.Title;
                }
            }
        }
    }
