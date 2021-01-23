    static void Main(string[] args)
    {
    List<int> testdata = new List<int>();
    testdata.Add(111111);
    testdata.Add(222222);
    testdata.Add(333333);
    foreach (int data in testdata)
    {
        new Thread(delegate(object arg)
        {
            DataTable dt = DB.GetData((int) arg);
            if (dt.Count > 0)
            {
                Console.WriteLine("Name: {0}", dt.Rows[0]["Name"];);
            }
            // Signal the CountdownEvent.
            countdownEvent.Signal();
        }).Start(data);
    }
    // Wait for workers.
    countdownEvent.Wait();
    Console.WriteLine("Finished."); 
    }
