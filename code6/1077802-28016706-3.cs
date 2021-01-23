    [TestMethod]
    public void TestMethod1()
    {
        string page = "http://upload.wikimedia.org/wikipedia/commons/5/53/Wikipedia-logo-en-big.png";
        // ... Use HttpClient.
        using (HttpClient client = new HttpClient())
        {
           byte[] result  = client.GetByteArrayAsync(page).Result;
           Console.WriteLine("length" + result.Length);              
        }
    }
