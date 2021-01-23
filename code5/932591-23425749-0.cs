    public partial class Login : Elysium.Controls.Window
    {
    ....
    ....
     else if (username.Text != "" && password.Password != "")
    {
    // Trigger this method in the login class.
    loginc.Login();        
    loginc.username=username.Text;
    loginc.pass=password.Password;
    }
    ....
