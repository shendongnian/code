    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    namespace ReadFromTextFileToTextBoxWebApp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var data = File.ReadAllText(Server.MapPath("~/App_Data/Details.txt"));
                HiddenField1.Value = data.ToString();   
            }           
        }
    }
