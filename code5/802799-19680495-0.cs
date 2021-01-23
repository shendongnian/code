    string _time_One = "08:30" ;
    string _time_Two = "08:35" ;
    
    TimeSpan ts = DateTime.Parse(_time_One) - DateTime.Parse(_time_Two);
    MessageBox.Show(String.Format("Time: {0:00}:{1:00}", ts.Hours, ts.Minutes));
