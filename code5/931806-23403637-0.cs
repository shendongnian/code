    for (int i = 0; i < value.Count; i++)
    {
        if (value[i] != 0)
        {
                chart1.Series["series1"].Points.Add(value[i]);
        }
        else
        {
            var point = chart1.Series["series1"].Points.Add(value[i]);
            point.IsEmpty = true;
        }
    }
