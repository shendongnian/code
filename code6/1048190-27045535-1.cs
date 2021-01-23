    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Test
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
              String arrName = "MyArray";
        String arrValue = "\"1\", \"2\", \"text\"";
    
        // Define the hidden field name and initial value.
        String hiddenName = "MyHiddenField";
        String hiddenValue = "3";
    
    
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
    
        // Register the array with the Page class.
        cs.RegisterArrayDeclaration(arrName, arrValue);
    
        // Register the hidden field with the Page class.
        cs.RegisterHiddenField(hiddenName, hiddenValue);
                }
            }
        }
