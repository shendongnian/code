    User user = new User();
    user.Email = textBoxEmail.Text;
    user.Password = textBoxPassword.Text;
    If(user.Authenticate())
    {
        //call new MainForm(user)
