    public Form1()
    {
        InitializeComponent();
        if (dt.Seconds % 10 > 0)
        {            
            initialValue = true;
            dateTimePicker1.Value = dt.Seconds (-(dt.Seconds % 10));
        }
        _prevDate = dateTimePicker1.Value;
    }
    private DateTime _prevDate;
    private bool initialValue = false;
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        if(initialValue)
        {
            initialValue = false;
            return;
        }
        DateTime dt = dateTimePicker1.Value;
        TimeSpan diff = dt - _prevDate;
        if (diff.Ticks < 0) 
            dateTimePicker1.Value = _prevDate.AddSeconds(-10);
        else 
            dateTimePicker1.Value = _prevDate.AddSeconds(10);
        _prevDate = dateTimePicker1.Value;
    }
