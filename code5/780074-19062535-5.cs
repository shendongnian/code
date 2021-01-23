    static void Main(string[] args)
    {
            
        string str = "A,B,C,D,E,F,G";
        string[] strArray = { "A,B", "C", "D,E", "F,G", "I,J,K", "L,M", "H,N" };
        List<string> results = new List<string>();
        foreach (var item in strArray)
        {
            if (str.Contains(item))
            {
                results.Add(item);
            }
        }
         
    }
