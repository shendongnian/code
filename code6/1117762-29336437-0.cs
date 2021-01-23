    private static void NoRedirect(string uri)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.AllowAutoRedirect = false;
        var resp = (HttpWebResponse)request.GetResponse();
        Console.WriteLine(resp.StatusCode);
        Console.WriteLine("Location: {0}", resp.Headers["Location"]);
        using (var reader = new StreamReader(resp.GetResponseStream()))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
