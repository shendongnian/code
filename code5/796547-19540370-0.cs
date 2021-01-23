    public static Range OldUnionRange(List<System.Drawing.Point> list,Range range, Boolean Even){
    Range RgEven = null;
    Boolean RgEvenBool = false;
    Range RgOdd = null;
    Boolean RgOddBool = false;
    for (int j = 0; j < list.Count; j++){
    System.Drawing.Point p = list[j];
    int x = p.X;
    int y = p.Y;
    if (x % 2 == 0 && Even)
    {Range rng = range.Cells[x + 1, y + 1];
    if (!RgEvenBool){
    RgEven = range.Cells[x + 1, y + 1];
    RgEvenBool = true;
    }
    RgEven = Shuttle_add_in_Loader.XlApp.Union(RgEven, rng);
    }
    else if (x % 2 != 0 && !Even)
    {Range rng = range.Cells[x + 1, y + 1];
    if (!RgOddBool)
    {
    RgOdd = range.Cells[x + 1, y + 1];
    RgOddBool = true;
    }
    RgOdd = Shuttle_add_in_Loader.XlApp.Union(RgOdd, rng);
    }
    }
    if (Even)
    {
    return RgEven;
    }
    else
    {return RgOdd;}
    }
