    using System;
    
    namespace WebApp.UserControlExample
    {
        public delegate void NameChangedEventHandler(string name);
        public partial class MyUserControl : System.Web.UI.UserControl
        {
            public event NameChangedEventHandler NameChanged;
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (NameChanged != null)
                    NameChanged(DropDownList1.SelectedValue);
            }
        }
    }
