    var dupl = new Dictionary<string, List<int>>();
    var d = a.Distinct();
    for (int i = 0; i < d.Count; ++i)
    {
       int match = 0;
       for (int j = 0; j < a.Count; ++j)
       {
           if (a[j] == d[i])
           {
              ++match;
              if (++match > 1)
              {
                  if (dupl.ContainsKey(d[i])) dupl[d[i]].Add(j);
                  else
                  {
                     dupl.Add(d[i], new List<int>());
                     dupl[d[i]].Add(j);
                  }
              }
           }
       }
    }
