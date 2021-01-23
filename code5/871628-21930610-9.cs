    IList<Range> rangeList = new RangeList();
    try
    {
        rangeList.Add(new Range { FromNumber = 12, ToNumber = 12 });
        rangeList.Add(new Range { FromNumber = 13, ToNumber = 20 }); // should NOT overlap
        rangeList.Add(new Range { FromNumber = 12, ToNumber = 20 }); // should overlap
    }
    catch ( ArgumentOutOfRangeException exception )
    {
        Console.WriteLine(exception.Message);
    }
