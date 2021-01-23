    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("fr-FR");
    List<decimal> lst = new List<decimal>()
    {
        909865747.98M,
        90986574798M
    };
    
    List<string> results = new List<string>();
    
    foreach(decimal d in lst)
    {
         if(d.Equals(decimal.Truncate(d)))
             results.Add(d.ToString("C0",ci));
         else
             results.Add(d.ToString("C",ci));
    }
