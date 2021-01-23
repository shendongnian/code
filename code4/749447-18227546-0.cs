    //the property in the login-form
    public MainForm { get; set; }
    //setting the property from the main-form
    var login = new LoginForm();
    login.MainForm = this;
    //closing of the mainform
    MainForm.Close();
