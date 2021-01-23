    using System;
    
    namespace WebApp.Attributes
    {
        public partial class _default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CompositeControl1.Age = 23;
                    CompositeControl1.Name = "Default";
                }
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                ltrlResult.Text = string.Format("<p>{0}</p><p>{1}</p>", CompositeControl1.Name, CompositeControl1.Age);
            }
        }
    }
