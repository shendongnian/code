    OpenFileDialog dlg;
    public Form1()
    {
        InitializeComponent();
        dlg = new OpenFileDialog();
        dlg.FileOk += dlg_FileOk;
    }
    void dlg_FileOk(object sender, CancelEventArgs e)
    {
        if (dlg.SafeFileName.Contains("#") || dlg.SafeFileName.Contains("+"))
        {
            e.Cancel = true;
            // show error message;
        }
    }
