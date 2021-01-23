    class Program
    {
     private const string URL =      "https://9833bf430be5620b7fa941ee5c3c7e2add61a86e:password@app.listen360.com/organizations/594214508264690689/reviews.xml";
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(URL);         
        // List data response.
        HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call!
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body. Blocking!              
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
