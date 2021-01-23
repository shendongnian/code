    XDocument doc = XDocument.Parse(e.Result);
    List<CUST_CONT> customers = new List<CUST_CONT>();
    
    customers = (from query in doc.Descendants("row")
                select new CUST_CONT
                {
                     Id = query.Element("Id").Value,
                     Name = query.Element("Name").Value,
                     Address = query.Element("Address").Value,
                     Favourite = (query.Element("Favourite").Value)
                }).ToList();
    for (int i = 0; i < customers.Count; i++)
    {
        if (customers.ElementAt(i).Favourite == "0")
        {
            customers.ElementAt(i).IsFavourite = "False";
        }
        else
        {
            customers.ElementAt(i).IsFavourite = "True";
        }
    }
    
    listBox1.DataContext = customers;
