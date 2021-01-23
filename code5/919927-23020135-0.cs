    private List<DateTime> clickTimes = new List<DateTime>();
    private void button1_Click(object sender, EventArgs e)
    {
        this.clickTimes.Add(DateTime.Now);
        if (this.clickTimes.Count > 2)
        {
             double averageSeconds = this.clickTimes.Zip(this.clickTimes.Skip(1), (a,b) => (b-a).TotalSeconds)).Average();
             // Do something with the average seconds between each click here
        }
    }
