    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace MyApplication
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                this.Title = "Title of my page";
            }
        }
    }
