    racks.OrderBy(a => { 
                            //use reflection get the property
                            PropInfo prop = a.GetType().GetProperty("price");
                            return prop;
                       })
