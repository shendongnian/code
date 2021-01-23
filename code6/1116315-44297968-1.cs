    private static void GetNodeIp(string hostName , string port , string sessionId)
    {
        try
        {               
            RestClient client = new RestClient("http://" + hostName + ":" + port + "/grid/api/testsession?session=" + sessionId);
            RestRequest req = new RestRequest(Method.GET);
            var resp = client.Execute(req);
            dynamic jsonData = JsonConvert.DeserializeObject(resp.Content);
            Console.WriteLine("Test Will run on Machine : {0}" ,new Uri(jsonData.proxyId.ToString()));
        }
        catch (Exception ex)
        {
        }
    }
