    var testItems = items
                       .Select(item => 
                           new TestItem {
                               Header = item.TestItemTypeName, 
                               Content = item
                           })
                        .ToList();
