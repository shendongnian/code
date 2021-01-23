    void Main()
    {
    	var fooList = new List<string>();
    	var barList = new List<string>();
    	var bazList = new List<string>();
    	ReverseLists(fooList, barList, bazList);
    }
    
    public static void ReverseLists(params IList [] sourceLists)
    {
        foreach (var sourceList in sourceLists)
        {
            MyReverse(sourceList); 
        }
    }
    
    public static void MyReverse(IList source)
    {
        var length = source.Count;
        var hLength = length / 2;
        for (var i = 0; i < hLength; i++)
        {
            var temp = source[i];
            source[i] = source[length - 1 - i];
            source[length - 1 - i] = temp;
        }
    }
