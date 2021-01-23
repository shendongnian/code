    public WorldMap()
    {
        CreateCellMap(100, 1, 100);
    
        AddObject(new DarkForestTreeA(), 1000, mCellMap.GetFreeCell); // note no () after method name
    }
    
    private void AddObject(GameObjectBase obj, int times, Func<Vector3> vectorFunc)
    {
        for (int i = 0; i < times; i++)
        {
            AddObject(obj, vectorFunc());
        }
    }
