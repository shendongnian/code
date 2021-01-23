    1. This is the best way to transfer data from one form to another,,
    On the LoginForm.cs write like this,
    ex.UserName=txtUserName.text;
    Password=txtPassword.text;
    
    MainForm mainForm = new MainForm(UserName,Password);
    
                            this.Hide();
                            mainForm.Show();
    
    2.In the MainForm.cs
     edit the   public MainForm(){}
    like this
    public MainForm(string userName,string password){
    
    
    }
