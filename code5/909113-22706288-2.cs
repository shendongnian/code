       public partial class login : System.Web.UI.Page
    {
    
    
     protected void Page_Load(object sender, EventArgs e)
     {
        
        
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        Class3.login(TextBoxLoginUser.Text, TextBoxLoginPass.Text);
     
     }
    }
