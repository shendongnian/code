    public override int Method1(int x,int y, out ConcurrentDictionary<string,int> dictionary)
    {
        dictionary = new ConcurrentDictionary<string,int>();
        // It doesn't make sense to check if it is empty here as it will always be empty
        // if(dictionary.IsEmpty)
        //  {
