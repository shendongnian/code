    string Album = Encoding.Default.GetString(Buffer, 63, 30).ValidateXML();
    string Artist = Encoding.Default.GetString(Buffer, 33, 30).ValidateXML();
    XMLFileToFile.WriteElementString(Artist, Album); //This should run smoothly.
    static string ValidateXML(this string value)
    {
       return value.Replace(@"""","&quot;").Replace("'","&apos;").Replace("<","&lt;").Replace(">","&gt;").Replace("&","&amp;");
    }
