    private MapItem GetTopItem(int X, int Y)
    {
        double Height = 0.0;
     //here you should initialize you array otherwhise use LIST<T>
        //MapItem[] TopItem = null;
        List<MapItem> topItems =  new         List<MapItem>(); 
        foreach (MapItem @class in this.FloorItems.Values)
        {
            if (@class.Int32_0 == X && @class.Int32_1 == Y)
            {
                Height += @class.Height;
                //TopItem[Height] = @class;
                 topItems.Add(@class); 
            }
        }
        //return TopItem.Max();
         return topItems.Last().Max(); 
    }
