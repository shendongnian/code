    private DateTime? keyUpTime = null;
    private DateTime? keyDownTime = null;
    private List<double> keyDownKeyUpMeasurements = new List<double>();
    private List<double> keyDownKeyDownMeasurements = new List<double>();
    private List<double> keyUpKeyDownMeasurements = new List<double>();
    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        DateTime prevKeyDownTime = keyDownTime;
        keyDownTime = DateTime.Now;
        if (prevKeyDownTime != null)
        {
            keyDownKeyDownMeasurements
                .Add(keyDownTime.Subtract(prevKeyDownTime).TotalMilliseconds);
        }
        if (keyUpTime != null)
        {
            keyUpKeyDownMeasurements
                .Add(keyDownTime.Subtract(keyUpTime).TotalMilliseconds);
        }
    }
    private void textBox_KeyUp(object sender, KeyEventArgs e)
    {
        keyUpTime = DateTime.Now;
        keyDownKeyUpMeasurements
            .Add(keyUpTime.Subtract(keyDownTime).TotalMilliseconds);
    }
