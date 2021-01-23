    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class Utilities_Master : System.Web.UI.MasterPage
    {
        public bool HeaderVisible
        {
            get { return lnkHeader.Visible; }
            set { lnkHeader.Visible = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            if (url.Contains("Giveaway"))
            {
            menubar.Visible = false; 
	    cnbody.Style.Add("width", "950px");
            }
            else
            {
            menubar.Visible = true; 
            }
        }
    }
