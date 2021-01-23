    Double[] data; // my data
    int i=0;
    
    chart1.Series["Chart"].Points[0].Clear(); // initialize the chart
    chart1.Series[""Chart"].Color = Color.Red; // initial color
    
    for(i=0; i < data.Length; i++)
    {
      if(i >= data.Length/2 )
         chart1.Series[""Chart"].Color = Color.Green; // use other color after certain data #
    
      chart1.Series["Chart"].Points.AddXY(i, data[i]);
    }
