    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace test_with_ajax
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            [WebMethod]
            public static object Show()
            {
                 object result = new 
    		{
    			TextboxName = "Sarthak";
    			TextBoxID = "66";
    		}
    		return result;
            }
        }
    }
