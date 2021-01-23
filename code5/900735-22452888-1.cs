    using System;
    using System.Collections.Generic;
    using System.Web.Services;
    
    namespace WebApp.PageMethods
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            [WebMethod]
            public static string GenerateLinks(int number)
            {
                List<string> a = new List<string>();
                for (int i = 0; i < number; i++)
                {
                    a.Add("<a href=\"javascript:GetTime()\">Get Time " + (i + 1) + "</a>");
                }
    
                return string.Join("<br/>", a);
            }
    
            [WebMethod]
            public static string GetTime(string guid)
            {
                return guid + " / " + DateTime.Now.ToLongTimeString();
            }
        }
    }
