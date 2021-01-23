    using System;
    using System.Web.UI.WebControls;
    
    namespace VMS_Calc
    {
        public partial class DeviceRow : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Page_PreLoad(object sender, EventArgs e)
            {
                pnlContainer.BorderStyle = this.BorderStyle;
               
            }
    
            public BorderStyle BorderStyle 
            {
                get {
                        if (ViewState["MyBorderStyle"] != null)
                        {
                            return(BorderStyle)ViewState["MyBorderStyle"];
                        }
                        return System.Web.UI.WebControls.BorderStyle.None;
                    }
                set
                {
                    ViewState["MyBorderStyle"] = value;
                    pnlContainer.BorderStyle = value;
                }
            }
      
        }
    }
