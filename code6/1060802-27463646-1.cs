    public static string CountMin(IList<string> inputList) 
    { 
        if (inputList == null || !inputList.Any()) return null;
        var result = inputList.Select(s => new 
                              { 
                                 Item = s,
                                 Count => s.Count(ch => ch == 'X')
                              })
                              .OrderBy(item => item.Count).First().Item;
    }
