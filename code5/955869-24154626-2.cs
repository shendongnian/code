    static void Main(string[] args)
    {
        try
        {
            var test = new performance("http://www.example.com");
            var x = InsertItem(test);
            
            //This makes the program wait for the returned Task to complete before continuing.
            x.Wait();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        }
    }
