    string sNoOffset = "2014-03-18T06:40:40";
    
    DateTime dt = DateTime.Parse(sNoOffset);
    
    TimeSpan ts = TimeSpan.Parse(s);//where s is the offset
    
    dt = dt.AddTicks(ts.Ticks);
    
    MessageBox.Show(dt.ToString());
    // Please customize the above lines of code to your liking.
