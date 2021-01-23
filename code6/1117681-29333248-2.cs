    private void button14_Click(object sender, EventArgs e)
    {
        xos = new double[period + 1];
        yos = new double[period + 1];
        x2os = new double[period + 1];
        y2os = new double[period + 1];
        for (int i = 0; i <= period; i++)
        {
            xos[i] = i+1;
            yos[i] = pot[i];
            listBox1.Items.Add(xos[i]);
            listBox1.Items.Add("y " + yos[i]);
        }
        for (int i = 0; i <= period; i++)
        {
             x2os[i] = i + 1;
             y2os[i] = pot2[i];
             listBox2.Items.Add(x2os[i]);
             listBox2.Items.Add("y "+y2os[i]);
 
        }
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.Series["Potražnja"].Points.DataBindXY(xos, yos);
        chart1.Series["Predviđanje"].Points.DataBindXY(x2os,y2os);
     }
