    var firstObjectList  = secondObjectList.AsParallel().Select(s => new FirstObject
                               {
                                   Name = s.Name,
                                   DecimalProp = Convert.ToDecimal(s.StringProp)
                               });
