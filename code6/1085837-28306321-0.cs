    var data = ((IEnumerable<object>)collection)
     .OrderByDescending(c => c.GetType().GetProperty("TS").GetValue(c))
     .GroupBy(c => c.GetType().GetProperty("PId").GetValue(c))
     .Select(c => c.First())
     .Where(c => !(bool)c.GetType().GetProperty("IsD").GetValue(c));
