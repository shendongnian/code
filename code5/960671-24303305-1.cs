    public Form1()
    {
        InitializeComponent();
        foreach (Control ctl in this.Controls)
            if (typeof(ctl) == NumericUpDown ) ctl.Leave += numericUpDown_Leave;
    }
            
    private void numericUpDown_Leave(object sender, EventArgs e)
        {
            NumericUpDown NumericUD =  (NumericUpDown) sender ;
            if (NumericUD.Value < 1 || NumericUD.Value > 6)
            {
                NumericUD.BackColor = Color.Red;
            }
            else
            {
                NumericUD.BackColor = Color.White;
            }
        }
