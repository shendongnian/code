    private ChatCallBack chatCallBack;
    public Account() //class constructor
    {
        InitializeComponent();
        chatCallBack = new ChatCallBack();
        chatCallBack.UserJoinedTheConversation += (sender, username) =>
        {
            Dispatcher.Invoke(() => updateUsersInConversation(username));
        };
    }
