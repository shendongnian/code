    private string username;
    
    public talkingWithProgram(string userName, string pcName)
    {
    InitializeComponent();
    this.Text = pcName;
    programQuestion.Text = "Whatcha wanna talk about \n" + userName + "?";
    this.userName = userName;
    }
    sportsCategories y = new sportsCategories(userName);
