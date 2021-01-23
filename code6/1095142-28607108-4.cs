    private int _timer1Ticks;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if(_timer1Ticks++ >= int.Parse(comboBox1.Text) / 10)
        {
            _timer1Ticks = 0;
            Update();
        }
    }
