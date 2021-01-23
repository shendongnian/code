    Dictionary<CultureInfo, List<string>> results = new Dictionary<CultureInfo, List<string>>()
    {
         {new System.Globalization.CultureInfo("fr-FR"),new List<string>()},
         {new System.Globalization.CultureInfo("es-CO"),new List<string>()}
    };
    foreach(decimal d in lst)
    {
          if (d.Equals(decimal.Truncate(d)))
          {
               foreach (var item in results)
               {
                   item.Value.Add(d.ToString("C0", item.Key));
               }
          }
          else
          {
               foreach (var item in results)
               {
                   item.Value.Add(d.ToString("C", item.Key));
               }
          }
    }
