    [WebMethod]
    public List<object> GetList()
    {
        List<object> list = new List<object>();
        
        list.Add(list1);
        list.Add(list2);
        list.Add(list3);
    
        return list;
    }
