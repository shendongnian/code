    DateTime start;
    private void button6_Click(object sender, EventArgs e)
    {
        //start
        start = DateTime.Now;
    }
    private void button5_Click(object sender, EventArgs e)
    {
        //end            
        MessageBox.Show((DateTime.Now - start).TotalSeconds.ToString());
    }
