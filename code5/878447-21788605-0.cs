    private object lockObj=new object();
    public void Run()
    {
    // thread alive is set to true, in the main program it is set to false when the user quits
    while (RestTestThread.ThreadAlive)
    {
        System.Threading.Thread.Sleep(1000);   // set to 1000 for quick testing
        try
        {
            lock(lockObj)
           {
               // get the data from the database and return to a List<string>
               List<string> postList = Controllers.OdbcController.GetRecords();
               // convert that list into a string
               string post = string.Join(",", postList.ToArray());
               // format that data
              string postData = "{\"Data\":[" + post.TrimEnd(new char[] { ',' }) + "]}";
              Program.postString.Clear();
              // test output
              Console.WriteLine(postData);
           }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            break;
         }
    }
}
