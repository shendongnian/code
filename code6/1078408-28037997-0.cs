        var DeliveryFee = x.Descendants("LineItemShipping").
            Select(e => {
                try
                {
                    var item = (double)e.Element("TotalPrice");  
                    return item;
                }
                catch(Exception ex)
                {
                    //This is just so it will compile and have a return value                        
                    return double.MinValue;
                }                  
            }).
            FirstOrDefault();
