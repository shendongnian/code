    List<CustomProduct> lst = new List<CustomProduct>();
     while reader.Read()
              {
                 CustomProduct cp = new CustomProduct();
                 cp.ProductName = reader.GetString(0); --where 0 is the column index
                 .....
                 lst.Add(cp);
              }
 
