    using System;
    using System.Web.UI;
    namespace Website
    {
        public partial class _410 : Page
        {
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                Response.Buffer = true;
                Response.StatusCode = 410;
                Response.Status = "410 Gone";
            }
            protected void Page_Load(object sender, EventArgs e)
            {
            }
        }
    }
