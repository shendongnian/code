    private DateTime keyUpTime;
    private DateTime keyDownTime;
    private List<double> keyDownKeyUpMeasurements = new List<double>();
    private List<double> keyDownKeyDownMeasurements = new List<double>();
    private void OnKeyDown()
    {
        DateTime prevKeyDownTime = keyDownTime;
        keyDownTime = DateTime.Now;
        if (prevKeyDownTime != null)
        {
            keyDownKeyDownMeasurements
                .Add(keyDownTime.Subtract(prevKeyDownTime).TotalMilliseconds);
        }
    }
    private void OnKeyUp()
    {
        keyUpTime = DateTime.Now;
        keyDownKeyUpMeasurements
            .Add(keyUpTime.Subtract(keyDownTime).TotalMilliseconds);
    }
