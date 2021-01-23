       static NameValueCollection GetCollection()
        {
    	NameValueCollection collection = new NameValueCollection();
    	collection.Add("Sam", "Dot Net Perls");
    	collection.Add("Bill", "Microsoft");
    	collection.Add("Bill", "White House");
    	collection.Add("Sam", "IBM");
    	return collection;
        }
    
        static void Main()
        {
    	NameValueCollection collection = GetCollection();
    	foreach (string key in collection.AllKeys) // <-- No duplicates returned.
    	{
    	    Console.WriteLine(key);
    	}
   
