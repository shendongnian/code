    using (var stream = new NetworkStream(...))
    {
        using (var sslStream = new SslStream(stream))
        {
            using (var reader = new StreamReader(sslStream))
            {
                reader.WriteLine(...);
            }
        }
    }
