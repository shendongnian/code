    public int GetClosestIndexAt(double position)
    {
        if (!myDataList.Any())
            return -1;
        return myDataList.Select((d,i) => new { Position = d.Position, Index = i })
              .MinBy(x => Math.Abs(x.Position - position))
              .Index;
    }
