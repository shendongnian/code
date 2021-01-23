    var list1 = new []
    {
        new {ID = "3", Date = "12/28/2013", Target = "1"},
        new {ID = "4", Date = "12/30/2013", Target = "33"}
    };
    var list2 = new[]
    {
        new {ID = "3", ASO = "100", Below = "50"},
        new {ID = "4", ASO = "40", Below = "33"}
    };
    var result = list1
        .Join(
            list2,
            arg1 => arg1.ID, 
            arg2 => arg2.ID,
            (arg1, arg2) => new 
            {
                arg1.ID, 
                arg1.Date, 
                arg1.Target, 
                arg2.ASO, 
                arg2.Below
            })
	.ToArray();
