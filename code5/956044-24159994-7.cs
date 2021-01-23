     private List<Item> myList = new List<Item>();
    [WebMethod]
    public void StoreObject(Item myObject)
    {
        myList.Add(myObject);
    }
