    StringBuilder sb = new StringBuilder();
    DateTime arrival = new DateTime(2014,4,22);
    DateTime departure = new DateTime(2014,4,25);
    int days = Convert.ToInt32((departure - arrival).TotalDays);
    var rng = Enumerable.Range(0,days+1).ToList();
    rng.ForEach(r => sb.Append(arrival.AddDays(r).ToShortDateString() + "|"));
    sb.Length--;
    Console.WriteLine(sb.ToString());
