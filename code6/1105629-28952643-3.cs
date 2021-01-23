    static List<MainModel> TestMethod()
    {
        var ids = new int[] { 1, 2, 3, 4, 5 };
        return ids.Select(id => new MainModel {Id = id, planeModel = GetPlanes()}).ToList();
    }
    static String GetPlanes()
    {
        return "PlanesTest";
    }
