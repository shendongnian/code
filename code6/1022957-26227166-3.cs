     public async Task<string> Buy(string stkName, int stkShares, double limitPrice)
     {
        try
        {
            using (MyWebClient client = new MyWebClient())
            {
                // use async API here to get the data, assuming existance of OpenReadAsync
                Stream data = await client.OpenReadAsync("http://localhost:8080/ExecuteOrder?symbol=" + stkName + "&limitprice=" + limitPrice + "&ordername=ARCA%20Buy%20ARCX%20Limit%20DAY&shares=" + stkShares);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                s = getBetween(s, "<Content>", "</Content>"); //this is a util function to parse the result
                // MessageBox.Show(s.ToString());
                data.Close();
                reader.Close();
                return s;
            }
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return "Nothing";
        }
    }
    public async Task<string> GetOrderNumber(string id)
    {
        string s = "";
        using (MyWebClient client = new MyWebClient())
        {
            try
            {
                WebRequest request = WebRequest.Create("http://localhost:8080/GetOrderNumber?requestid=" + id);
                WebResponse response = await request.GetResponseAsync();
                var reader = new StreamReader(response.GetResponseStream());
                s = await reader.ReadToEndAsync();
                Console.WriteLine(s);
                return s;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "";
            }
        }
    }
