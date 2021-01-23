    private void ManipulateProjects()
    {
        object[] projects = new object[5];
        RootObj item1Obj = new RootObj();
        List<ObjectList> item1List = new List<ObjectList>();
        item1List.Add(new ObjectList("1", "Rone1", "htt://google1.com"));
        item1List.Add(new ObjectList("2", "Rone2", "htt://google2.com"));
        item1List.Add(new ObjectList("3", "Rone3", "htt://google3.com"));
        item1Obj.objectList = item1List;
        projects[0] = item1Obj;
        RootObj item2Obj = new RootObj();
        List<ObjectList> item2List = new List<ObjectList>();
        item2List.Add(new ObjectList("10", "Rone10", "htt://google10.com"));
        item2List.Add(new ObjectList("12", "Rone12", "htt://google20.com"));
        item2List.Add(new ObjectList("13", "Rone13", "htt://google30.com"));
        item2Obj.objectList = item2List;
        projects[1] = item2Obj;
        foreach (RootObj item in projects)
        {
            if (item == null) continue;
            List<ObjectList> items = item.objectList;
            foreach (ObjectList item1 in items)
            {
                //Response.Write(item1.id + " " + item1.name + " " + item1.url + "<br />");
            }
        }
    }
