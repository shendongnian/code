    DataPoint[] data60k1 = new DataPoint[60000];
    int windowSize = 60;
    HScrollBar scroller = new HScrollBar();
    private void button14_Click(object sender, EventArgs e)
    {
        // creating a few test data..
        for (int i = 0; i < data60k1.Length; i++) data60k1[i] = 
                                                  new DataPoint(i, 3 + Math.Sin(i / 100f));
        // set up a HScrollBar:
        chart1.Controls.Add(scroller);
        scroller.Dock = DockStyle.Bottom;
        scroller.Maximum = data60k1.Length - windowSize;
        scroller.LargeChange = windowSize ;
        scroller.Scroll += scroller_Scroll;
        // show first portion..
        scroller_Scroll(null, null);
    }
    void scroller_Scroll(object sender, ScrollEventArgs e)
    {
        chart1.Series[0].Points.Clear();
        for (int i = scroller.Value; i < scroller.Value + windowSize; i++) 
                     chart1.Series[0].Points.Add(data60k1[i]);
    }
