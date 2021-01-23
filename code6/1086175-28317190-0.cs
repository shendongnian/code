    private static void YourApiCall(string email)
    {
       //...
    }
    
    private static void RunApiWithEmailsFrom(string file)
    {
        System.IO.File.ReadLines(file).ToList().ForEach(YourApiCall);
    }
