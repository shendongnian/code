    [WebMethod]
    public List<List<object>> GetList()
    {
        List<List<object>> list = new List<List<T>>();
        
        list.Add(list1);
        list.Add(list2);
        list.Add(list3);
    
        return list;
    }
