    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace UCDynamic
    {
        public delegate void FirstNameValueChanged(string value);
    
        public partial class UCTest : System.Web.UI.UserControl
        {
            public event FirstNameValueChanged FirstNameChanged;
            
            protected void txtFirstName_TextChanged(object sender, EventArgs e)
            {
                FirstNameChanged.Invoke(txtFirstName.Text);
            }
        }
    }
