    [WebMethod]
    [System.Xml.Serialization.XmlInclude(typeof(Customer))]
    public ArrayList GetCustomerList()
    {
        ArrayList list = new ArrayList();
        list.Add(new Customer("Mohammad", "Azam"));
        return list;
    }
