    using System;
    using System.Diagnostics;
    
    namespace WebApp.SignalR.GridUpdatePanel
    {
        public partial class SingalRPage : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Label1.Text = DateTime.Now.ToLongTimeString();
                }
            }       
    
            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                Debug.Print("LinkButton1_Click");
                Label1.Text = DateTime.Now.ToLongTimeString();
                GridView1.DataBind();
            }
        }
    }
