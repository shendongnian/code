    public mainFrm()
    {
        InitializeComponent();
    
        txtFormat.TextChanged += OnTextChanged;
    }
    
    private void OnTextChanged(object sender, KeyEventArgs e)
    {
        txtNewFormat.Text = txtFormat.Text;
    }
