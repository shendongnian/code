    public void ratePick(int h, int m, int s)
      {
         TimeSpan ts = new TimeSpan(h, m, s);
         double total = ts.TotalSeconds;
         linesPicked = Convert.ToDouble(total/lines);
