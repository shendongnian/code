    List<NavigationContext> navigationObjects = e.Parameter as List<NavigationContext>;
    if(null != navigationObjects)
    {
        foreach (NavigationContext navobj in navigationObjects)
        {
            myfiller += navobj.ID.ToString() + "  " + navobj.Name + "  " + navobj.Description+ "\n";
        }
    }
