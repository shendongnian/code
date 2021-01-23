    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Click += Edit_Button_Click;
            this.Form.Controls.Add(b);
        }
    
    
        protected void Edit_Button_Click(object sender, EventArgs e)
        {
            Response.Write(1111111111);
        }
    }
