    using System;
    
    namespace UserControlTest
    {
        public partial class TestForm : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Label1.Text = XTextBox.MyDate.HasValue? ((DateTime)XTextBox.MyDate).ToString("yyyy-MM-dd") : "";
            }
    
            protected void Button1_Click(object sender, EventArgs e){ }
        }
    }
