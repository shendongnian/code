    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Init()
        {
            GenerateContorls();
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        private void GenerateContorls()
        {
            TextBox newTxt = new TextBox() { ID = "txtsend" };
    
            Button newBtn = new Button() { Text = "Send", ID = "btnsend" };
            newBtn.Click += btnsend_Click;
    
            phHolder.Controls.Add(newTxt);
            phHolder.Controls.Add(newBtn);
        }
    
        protected void btnsend_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)this.FindControl("txtsend");
            
            //your code
        }
    }
