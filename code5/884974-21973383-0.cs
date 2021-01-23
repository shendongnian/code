    var inputPswrdForm = new InputPswrd();
    inputPswrdForm.ShowDialog();
    if (!inputPswrdForm.IsUserAuthenticated)
        // password was wrong, take some action
    InitializeComponent();
