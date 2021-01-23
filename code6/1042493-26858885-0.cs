    public Form1()
    {
        InitializeComponent();
        
        txtHost.TextChanged += textBox_TextChanged;
        txtUploadFile.TextChanged += textBox_TextChanged;
        textBox_TextChanged(null, null);
    }
    private void textBox_TextChanged(Object sender, EventArgs e)
    {
        btnUpload.Enabled = txtHost.TextLength > 0 && txtUploadFile.TextLength > 0;
    }
