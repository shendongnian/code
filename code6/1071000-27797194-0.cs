    private void setUpPage()
    {
        if (Session["User"] != null)
        {
            RegisterRelated.Visible = false;
            LoginRelated.Visible = false;
            InPage.Visible = true;
            WelcomeTag.Text = "Welcome, " + ((User)Session["User"]).Username + ".";
        }
        else
        {
            RegisterRelated.Visible = true;
            LoginRelated.Visible = true;
            WelcomeTag.Text = String.Empty;
            InPage.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Call if not in response to button click
        if(!IsPostBack)
        {
           setUpPage();
        }
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Label Reply = new Label();
        if (Session["User"] == null)
        {
            Result myRegResult = Result.IN_PROG;
            User myAddedUser = new User(UserTB.Text, PasswordTB.Text, EmailTB.Text);
            DbManager.OpenDbConnection();
            myRegResult = DbManager.Register(myAddedUser); //Connection with the database.
            Reply.Text = resultToString(myRegResult);
            Reply.ForeColor = resultColor(myRegResult);
        }
        else
        {
            Reply.Text = "You must log out before you register.";
            Reply.ForeColor = resultColor(Result.EXEC_ERROR);
        }
        Answer.Controls.Add((Control)Reply);
        //Reset_Fields();
        //Reset the fields as required AFTER you have done what you need with the database
        setUpPage();
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        Label Reply = new Label();
        LoginProc Status = LoginProc.IN_PROG;
        DbManager.OpenDbConnection();
        Status = DbManager.Login(LoginUserTB.Text, LoginPassTB.Text); //Connection with the database
        Reply.Text = ProcToString(Status);
        Reply.ForeColor = ProcToColor(Status);
        LogAnswer.Controls.Add(Reply);
        if (Status == LoginProc.FINE)
           Session["User"] = new User(LoginUserTB.Text, LoginPassTB.Text, null);
        //Reset_Fields();
        //Reset the fields as required AFTER you have done what you need with the database
        setUpPage();
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        //Reset the fields as required AFTER you have done what you need with the database
        setUpPage();
    }
