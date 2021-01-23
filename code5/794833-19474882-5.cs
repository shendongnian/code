    public SplitPage1()
        {
            InitializeComponent();
            SharingManager.ValueChanged += UpdateTextBox;
    
        }
    public void UpdateTextBox(object sender, NumericEventArgs e)
    {
        r1SSLBox.Text = e.Value.ToString(); // Update textBox
    }
