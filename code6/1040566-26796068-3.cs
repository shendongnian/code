    // From text
    string text = // Json text as string
    //// This is kind of a hack, however you do it it's easiest to work with a stream
    byte[] chars = text.ToCharArray().Select(c => Convert.ToByte(c)).ToArray();
    using (Stream stream = new MemoryStream(chars))
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(root));
        root result = (root)serializer.ReadObject(stream);
    }
    // From web request
    HttpWebResponse request = // Get your request object back from a WebRequest object
    using (Stream stream = request.GetResponseStream())
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(root));
        root result = (root)serializer.ReadObject(stream);
    }
