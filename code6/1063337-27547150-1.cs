    public void GetCustomerResults(List<CustomerFilter> accounts) {
      Dictionary<string, HashSet<int>> lookup =
        accounts.ToDictionary(a => a.CustomerID, a => new HashSet<int>(a.LocationID));
        var locations =
          ctx.Portal_SurveyLocations
          .Where(w =>
            lookup.ContainsKey(w.CustNum) &&
            lookup[w.CustNum].Contains(w.LocationKey))
          .OrderBy(o => o.LocationKey);
    }
