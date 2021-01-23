    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace TestWizard
    {
        public class MyUserControlData
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
        }
    
        public partial class MyUserControl : System.Web.UI.UserControl
        {
            public MyUserControlData Data
            {
                get
                {
                    return new MyUserControlData() 
                           { Text1 = txt1.Text, Text2 = txt2.Text };
                }
                set
                {
                    txt1.Text = value.Text1;
                    txt2.Text = value.Text2;
                }
            }
        }
    }
