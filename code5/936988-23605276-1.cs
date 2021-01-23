    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    
    namespace Web
    {
        public partial class Home : System.Web.UI.Page
        {
          
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   
                }
            }
            [WebMethod]
            public static List<string> GetAutoCompleteData(string code)
            {
                List<string> list = new List<string>(); 
                list.Add("delhi");
                list.Add("noida");
                list.Add("gurgaon");
                return list.Where(i => i.StartsWith(code)).ToList();
            }
            
        }
    }
