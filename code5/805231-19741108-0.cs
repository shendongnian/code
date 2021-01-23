    var _timer = new Timer() { Interval = 3000 };
    private void autoModeTempBtn_Click(object sender, EventArgs e)
    {
        if (!validateSerialNumber())
            return;
        if (!_timer.Enabled)
        {
            _timer.Start();
            autoModeTempBtn.Text = "hello";
        }
        else
        {
            _timer.Stop();
            autoModeTempBtn.Text = "Get Temperature Auto Mode";
        }
    }
