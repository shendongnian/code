    public ActionNotes()
    {
        InitializeComponent();
        Loaded += (sender, e) => MessageBox.Show(this.WorkID.ToString());
    }
