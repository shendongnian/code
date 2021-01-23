    using System;
    using System.Web.UI.Adapters;
    namespace SampleWebApplication
    {
        public class PageTitleAdapter : PageAdapter
        {
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                this.Page.Title = "Somesite - " + this.Page.Title;
            }
        }
    }
