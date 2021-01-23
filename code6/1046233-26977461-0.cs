    static void DownloadAndShowHeaders()
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                client.DownloadString("http://google.com");
                foreach (string name in client.ResponseHeaders.Keys)
                {
                    Console.WriteLine(name + "=" + client.ResponseHeaders[name]);
                }
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Status);
            }
            Console.ReadLine();
        }
    }
