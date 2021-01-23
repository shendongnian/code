    private UserLoginForm uform;
    public UserLogin(UserLoginForm loginForm)
    {
       uform = loginForm;
    }
 
    public void checklogin()
    {       
        if (uform.userID == "123" && uform.userPASS == "123")
        ...
    }
