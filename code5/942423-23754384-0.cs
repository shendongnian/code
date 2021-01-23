    static void RunOnExit(object sender, EventArgs e)
    {
       TimeSpan passedTime = DateTime.Now.Subtract(appStart);
       MessageBox.Show("Program time: " + passedTime.Seconds);
    }
