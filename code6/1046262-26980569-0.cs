    //consider keys held less than one second a short keypress event
    const double longThresholdMs = 1000.0;
    Dictionary<Keys, DateTime> keyDownTimes = new Dictionary<Keys, DateTime>();
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (!keyDownTimes.ContainsKey(e.KeyCode))
        {
            keyDownTimes[e.KeyCode] = DateTime.Now;
        }
    }
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (keyDownTimes.ContainsKey(e.KeyCode))
        {
            if (DateTime.Now.Subtract(keyDownTimes[e.KeyCode]).TotalMilliseconds > longThresholdMs)
            {
                Console.Out.WriteLine(e.KeyCode + " long press");
            }
            else
            {
                Console.Out.WriteLine(e.KeyCode + " short press");
            }
            keyDownTimes.Remove(e.KeyCode);
        }
    }
