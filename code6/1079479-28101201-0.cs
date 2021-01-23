    public frmInput()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Globals.sheet1.textbox1.text="Test"; //I was missing Globals
    }
}
