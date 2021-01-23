    DateTime start;
    private void button6_Click(object sender, EventArgs e)
    {
        //start
        start = DateTime.Now;
    }
    private void button5_Click(object sender, EventArgs e)
    {
        //end            
        TimeSpan ts = DateTime.Now - start;
        MessageBox.Show(String.Format("{0} minutes and {1} seconds", 
                        Math.Floor(ts.TotalMinutes), ts.Seconds));
    }
