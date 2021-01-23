    RootObject robj = new RootObject() 
    {
        inchistory = new List<Inchistory>() 
        {
           new Inchistory() 
           {
               r = "foo",
               reference = "bar",
               customerinfo = new CustomerInfo()
               {
                    customername = "joe blogs",
                    address = "somewhere",
                    postcode = "xxx xxxx"
               },
               region = "somewhere"
           },
           new Inchistory()
           {
               // etc
           }
        }
    };
