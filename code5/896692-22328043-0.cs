    Dim groupedItems = From item In LinqueResult
                        OrderBy item.Category
                        Group item By item.GetType()
                            .GetProperty("Test")
                            .GetValue(item)
                            .ToString() 
                        Into groupPropertie 
                        Select New KeyedList(Of String, ItemToDisplay)(groupPropertie);
