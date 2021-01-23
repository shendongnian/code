    [WebMethod]
    public List<List<T>> GetList()
    {
        List<List<T>> list = new List<List<T>>();
        
        list.Add(list1);
        list.Add(list2);
        list.Add(list3);
    
        return list;
    }
