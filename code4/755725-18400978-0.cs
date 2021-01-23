    protected void Page_Load(object sender, EventArgs e)
    {
        Timer1.Interval = 2000; // set your interval
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
         int result =  RadioButtonList1.SelectedIndex;
    }
