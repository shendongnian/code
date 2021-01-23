    public mainFrm()
    {
        InitializeComponent();
    
        txtFormat.TextChanged += OnTextChanged;
    }
    
    private void OnTextChanged(object sender, EventArgs e)
    {
        txtNewFormat.Text = txtFormat.Text;
    }
