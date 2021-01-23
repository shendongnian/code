    class Program
    {
        static void Main(string[] args)
        {
            var myMatchConditions = new int?[][]
                { 
                    new int?[] { 1, 1, 100, null }, 
                    new int?[] { 2, 2, 125, null }, 
                    new int?[] { 3, 3, null, 175 }, 
                    new int?[] { 4, 4, 125, 175 }
                };
            var myData = new MyTableItem[]
                {
                    new MyTableItem { id = 1, listId = 1, listFieldValue = 150, parentId = 1 },
                    new MyTableItem { id = 2, listId = 1, listFieldValue = 75, parentId = 1 },
                    new MyTableItem { id = 3, listId = 2, listFieldValue = 150, parentId = 1 },
                    new MyTableItem { id = 4, listId = 4, listFieldValue = 150, parentId = 1 },
                    new MyTableItem { id = 5, listId = 5, listFieldValue = 150, parentId = 1 },
                };
            var matches = from d in myData
                          where myMatchConditions.Any(cond => (
                                    (cond[0] == d.listId) && 
                                    (cond[1] == 1 ? d.listFieldValue == cond[2] :
                                        (cond[1] == 2 ? d.listFieldValue > cond[2]  :
                                            (cond[1] == 3 ? d.listFieldValue < cond[3] :
                                                (cond[1] == 4 ? d.listFieldValue > cond[2] && d.listFieldValue < cond[3] : false)
                                            )
                                        )
                                    )
                                ))
                          group d by d.parentId into g
                          select g;
                          
        }
        class MyTableItem
        {
            public long id { get; set; }
            public long listId { get; set; }
            public long listFieldValue { get; set; }
            public long parentId { get; set; }
        }
    }
