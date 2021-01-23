      var results1 = flatNodes.Select(
       list => list
      .Select((d, i) => new KeyValuePair<int, FlatData>(i, d))
      .ToDictionary(pair => string.Format("level{0}", pair.Key + 1), pair => pair.Value.Text));
      results1.Add("val", 2); // Add your extra value.
      var results = results1.ToList();
       retVal.Data = new List<object>{JsonConvert.SerializeObject(new { data = results }, Formatting.Indented)};
      return retVal;
