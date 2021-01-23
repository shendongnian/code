    static void Main(string[] args)
    {
        using (var client = new WebClient())
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("_ctl1:userName", "Username");
            collection.Add("_ctl1:passWord", "Password");
            var response = client.UploadValues("http://localhost:7727/Default.aspx", collection);
            Console.WriteLine(Encoding.UTF8.GetString(response));
        }
    }
