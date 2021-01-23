    public static string SerializeToXml<T>(T ThisTypeInstance)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string strReturnValue = null;
        //SerializeToXml<T>(ThisTypeInstance, new System.IO.StringWriter(sb));
        SerializeToXml<T>(ThisTypeInstance, new StringWriterWithEncoding(sb, System.Text.Encoding.UTF8));
        
        strReturnValue = sb.ToString();
        sb = null;
        return strReturnValue;
    } // End Function SerializeToXml
