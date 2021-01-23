    List<Data.Struct> sList = new List<Class.Struct>();
    
    sList.Add(new Data.Struct("Hello", false, new Vector2(150, 150), 0));
    sList.Add(new Data.Struct("Cruel", true, new Vector2(150, 150), 1));
    sList.Add(new Data.Struct("World", true, new Vector2(150, 150), 0));
    
    bool value = sList.Any(s => s.getID == 1);
