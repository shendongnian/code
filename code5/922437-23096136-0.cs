    public static void AddFormData(this HttpWebRequest request, IDictionary<string, string> data)
    {
        using (var memStream = new MemoryStream())
        using (var writer = new StreamWriter(memStream))
        {
            bool first = true;
            foreach (var d in data)
            {
                if (!first)
                    writer.Append("&");
                writer.Write(Uri.EscapeDataString(d.Key));
                writer.Write("=");
                writer.Write(Uri.EscapeDataString(d.Value));
                first = false;
            }
            writer.Flush();
            request.ContentLength = memStream.Length;
            memStream.Position = 0;
            using (var reqStream = request.GetRequestStream())
            {
                memStream.CopyTo(reqStream);
            }
        }
    }
