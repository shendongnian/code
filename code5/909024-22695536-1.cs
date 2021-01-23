    foreach (DataRow dr in dt.Rows)
    {
        SPBusinesslogic ab = new SPBusinesslogic();  //businesslogic class
        string prod;
        prod = ab.CheckProduct(id);                   
        list.Add(prod);
    }
