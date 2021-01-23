    private static void Main(string[] args)
    {
        WebRequest request = WebRequest.Create("http://google.com/12345"); //generate 404
        try
        {
            WebResponse response = request.GetResponse();
        }
        catch(WebException ex)
        {
            HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
            if (errorResponse == null)
                throw; //errorResponse not of type HttpWebResponse
            string responseContent = "";
            using(StreamReader r = new StreamReader(errorResponse.GetResponseStream()))
            {
                responseContent = r.ReadToEnd();
            }
            Console.WriteLine("The server at {0} returned {1}", errorResponse.ResponseUri, errorResponse.StatusCode);
            Console.WriteLine("With headers:");
            foreach(string key in errorResponse.Headers.AllKeys)
            {
                Console.WriteLine("\t{0}:{1}", key, errorResponse.Headers[key]);
            }
            Console.WriteLine(responseContent);
        }
        Console.ReadLine();
    }
