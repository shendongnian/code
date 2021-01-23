    private Timer _timer = new Timer();
    _timer.Interval = 10; // miliseconds
    void Form1_KeyDown(object sender, KeyEventArgs e)
    {        
        if (e.KeyCode == Keys.A)
        {
            _timer.Start();
        }
        if (e.KeyCode == "KEY_FOR_STOPPING_ANIMATION")
        {
            _timer.Stop();
        }
    }
    void timer1_Tick(object sender, EventArgs e)
    {
        MoveLeft();
    }
    
