    public MainForm()
    {
        InitializeComponent();
        foreach (Control control in this.Controls)
        {
            if (typeof(control)==typeof(TextBox))
            {
                (control as TextBox).TextChanged += CommonHandler_TextChanged;
            }
        }
    }
    private void CommonHandler_TextChanged(object sender, EventArgs e)
    {
        int number;
        string input=(sender as TextBox).Text;
        bool isnumber=false;
        isnumber = Int32.TryParse(input, number);
        if(isnumber==false)
        {
            yourLabel.Text = "This textbox contains an incorrect number: "
                             +(sender as TextBox).Name;
        }
        else{ /*use the number*/ }
    }
