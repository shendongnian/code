    // assume our list of integers it called values
    var splitByZero = values.Aggregate(new List<List<int>>{new List<int>()},
                                       (list, value) => {
                                           list.Last().Add(value);
                                           if (value == 0) list.Add(new List<int>());
                                           return list;
                                       });
