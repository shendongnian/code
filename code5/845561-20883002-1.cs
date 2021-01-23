    var result = from p in priceList
                 select new 
                        {
                           Price1 = p.Price1,
                           Price2 = p.Price2,
                           Price3 = p.Price3,
                           Price4 = p.Price4, 
                           ColSum = p.Price1 + p.Price2 + p.Price3 + p.Price4 + p.Price5
                         };
