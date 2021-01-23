    TimeSpan correction = new TimeSpan(0);
    string zone = "ET";
    private void timer1_Tick(object sender, EventArgs e)
    {
        // display the corrected time with its name
        time.Text = (DateTime.Now + correction).ToString("h:mm:ss ") + zone;
    }
    private void Central_Click(object sender, EventArgs e)
    {
        correction = new TimeSpan(-1, 0, 0);  // set the hours of the new zone
        zone = "CT";                         // set its name
    }
