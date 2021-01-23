    [WebMethod]
    public List<IList> GetList()
    {
        List<IList> list = new List<IList>();
        
        list.Add(list1);
        list.Add(list2);
        list.Add(list3);
    
        return list;
    }
