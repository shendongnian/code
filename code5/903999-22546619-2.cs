    BaseC<String> d1 = PopulateClass<String>();
    System.Diagnostics.Debug.Print(d1.recs.First().ToString());
    System.Diagnostics.Debug.Print(d1.recs.First().GetType().ToString());
    BaseC<int> d2 = PopulateClass<int>();
    System.Diagnostics.Debug.Print(d2.recs.First().ToString());
    System.Diagnostics.Debug.Print(d2.recs.First().GetType().ToString());
