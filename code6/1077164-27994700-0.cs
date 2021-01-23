    class Program
    {
        static void Main(string[] args)
        {
            // Put your cookies content here
            string myCookies = "Cookie1=Value; Cookie2=Value";
            // The URL you want to send a request
            string url = "https://www.google.com.br/";
            using (var client = new WebClient())
            {
                // If you want to attach cookies, you can do it 
                // easily using this code.
                client.Headers.Add("Cookie", myCookies);
                // Now you get the content of the response the way 
                // better suits your application.
                // Here i'm using DownloadString, a method that returns
                // the HTML of the response as a System.String.
                // You can use other options, like OpenRead, wich
                // creates a Stream to get the Response content.
                string responseContent = client.DownloadString(url);
                // If you want to save the cookies of the response to
                // use them later, just use the ResponseHeaders property.
                string responseCookies = client.ResponseHeaders["Set-Cookie"];
                // Here is the response of your question (I I'm correct). 
                // If you need to use the same instance of WebClient to make
                // another request, you will need to clear the headers that 
                // are being used as cookies.
                // You can do it easily by using this code.
                client.Headers.Remove("Cookie");
            }
        }
    }
