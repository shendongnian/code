    tableItems = tableItems.OrderByExcept(
                             item => item.ItemName == "TestSubject3",
                             items => items.OrderBy(MyTableItem => MyTableItem.ItemName)
                                           .ThenBy(MyTableItem => MyTableItem.TimeStamp))
                           .ToList();
