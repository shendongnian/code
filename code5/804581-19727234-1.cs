    using System;
    using System.IO;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Xml.Linq;
    
    namespace JFA_Admin
    {
        public partial class MasterPageSimple : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                lb_Version.Text = ConfigurationManager.AppSettings["Env"] + ": " + ConfigurationManager.AppSettings["Ver"];
            }
        }
    }
