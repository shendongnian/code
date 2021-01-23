    public IEnumerable<Bar> GroupIntoBars(IEnumerable<IGrouping<DateTime, Bar>> groups)
    {
        return groups.Select(GetBar);
    }
    public Bar GetBar(IEnumerable<Bar> bars)
    {
        Bar ret = new Bar();
        Bar last = null;
        int index = -1;
        foreach(var v in bars.OrderBy(c => c.StartingDate))
        {
            index++;
            if(index == 0)
            {
                ret.Open = v.Open;
                ret.StockDate = v.StockDate;
                ret.High = v.High;
                ret.Low = v.Low;
            }
            else
            {
                ret.High = Math.Max(ret.High, v.High);
                ret.Low= Math.Max(ret.Low, v.Low);
            }
            last = v;
        }
        if(last == null) throw new ArgumentException("Collection cannot be empty!");
        ret.Close = last.Close;
        return ret;
    }
