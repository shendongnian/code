    List<List<int>> a2DList = new List<List<int>>()
    {
        new List<int>()
        {
            0,1,2,3
        },
        new List<int>()
        {
            4,5,6,7,8
        }
    };
    				
    	
    Console.WriteLine(string.Join(",",a2DList.SelectMany(s => s).ToArray().Select(s => s)));
