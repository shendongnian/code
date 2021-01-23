    public LoadDataForm(string initvalue)
        {
            InitializeComponent();
            textBox1.Text = initvalue;
        }
    private void ApplyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
