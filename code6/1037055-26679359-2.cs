    int a = 1;
    int b = 2;
    string[] seriesArray = { "Cats", "Dogs" };
    private void Form1_Load(object sender, EventArgs e)
    {
        // Set palette.
        this.chart1.Palette = ChartColorPalette.SeaGreen;
        // Set title.
        this.chart1.Titles.Add("Pets");
        // Add series
        this.chart1.Series.Clear();
        for (int i = 0; i < seriesArray.Length; i++)
        {
            chart1.Series.Add(seriesArray[i]);
        }
        // hook up timer event
        timer1.Tick += timer1_Tick;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        a++;
        b++;
        // Data array
        int[] pointsArray = { a, b };
        for (int i = 0; i < seriesArray.Length; i++)
        {
            // Add point.
            chart1.Series[i].Points.Add(pointsArray[i]);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Start();
    }
