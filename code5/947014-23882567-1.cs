    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    
    namespace Web
    {
        public partial class PHP : System.Web.UI.Page
        {
            public class aPersonalDetails
            {
                public string strName { get; set; }
            }
            public class aInsurance
            {
                public int coverLife { get; set; }
            }
            public class value
            {
                public int fSalary { get; set; }
                public int fHomeMortgage { get; set; }
                public aInsurance aInsurance { get; set; }
                public aPersonalDetails aPersonalDetails { get; set; }
            }
            public class testop
            {
                public string action { get; set; }
                public string resource { get; set; }
                public value value { get; set; }
                //value
            }
            public class op
            {
                public string resource { get; set; }
                public testop[] testOps { get; set; }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            [WebMethod]
            public static bool v3(string format, op ops)
            {
                bool result = false;
                //Write code here 
                return result;
            }
        }
      
    }
