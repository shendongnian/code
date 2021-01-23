    public MainWindow()
    {
    try
        {
        InitializeComponent();
        }
    catch (Exception e)
        {
        MessageBox.Show("Error initializing main chat window " + e.Message + " " + e.Source + " " + e.HelpLink.ToString() + " " + e.TargetSite);
        }
    MessageBox.Show(string.Format("name: {0}, UserName: {1}", name, name.UserName));
    if (string.IsNullOrEmpty(name.UserName))
        try
            {
            name.ShowDialog();
            }
        catch (Exception e)
            {
            MessageRecieved("ERROR", e.Message, false);
            }
    network = new p2pchat();
    MessageBox.Show(string.Format("ChatText: {0}, network: {1}", ChatText, network));
    ChatText.AppendText("port " + network.Port + " may need to be forwarded to accept incoming connections\r");
    //add the handlers
    network.ReceivedMessageHandler += MessageRecieved;
    network.NewUserHandler += NewUser;
    network.MyUserName = name.UserName;
    network.Start();
    }
