    [HttpPost]
    public Boolean PostDataToDB(int n, string s)
    {
        //validate and write to database
        return false;
    }
    
    public async bool CallMethod()
        {
            var rootUrl = "http:...";
            bool result;
            using (var client = new WebClient())
            {
                var col = new NameValueCollection();
                col.Add("n", "1");
                col.Add("s", "2");
                var res = await client.UploadValuesAsync(address, col);
                string res = Encoding.UTF8.GetString(res);
                result = bool.Parse(res);
            }
        
        return result;
    }
