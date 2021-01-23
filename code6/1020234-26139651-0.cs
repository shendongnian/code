       Series s = new Series("First");
       s.Points.AddXY("a", 10);
       s.Points.AddXY("b", 10);
       s.Points.AddXY("c", 10);
       chart1.Series.Add(s);
       Series s2 = new Series("Second");
       s2.Points.AddXY("c", 30);
       chart1.Series.Add(s2);
