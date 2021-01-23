    private static frmWebInput MyForm { get; set; }
    private static int _connectedUsers = 0;
    public static int connectedUsers {
        get { return _connectedUsers; }
        set
        {
            _connectedUsers = value;
            MyForm.ConnectedUserCount.Text = String.Format("Connected Users: {0}", value);
        }
    }
