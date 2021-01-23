    public Form2()
    {
        InitializeComponent();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.No;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Yes;
    }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.DialogResult == DialogResult.No)
        {
            DialogResult = DialogResult.None;
            e.Cancel = true;
        }
    }
