    private List<string> _MyList = new List<string>();
    
    private void InitializeList()
    {
        //code here to fill list.
         
        //Keep in mind, that binary search works on sorted lists.
        _MyList.Sort(/* Place your object comparer here.  */);
    }
 
    //Make a copy in an array.
    public string[] MyListAsArray
    {
        get { return _MyList.ToArray(); }
    }
    public int GetBinarySearchIndex(string value)
    {
        return Array.BinarySearch(MyListAsArray, value/*, Place your object comparer here.  */);
    }
