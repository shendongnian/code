    var httpWebRequest = (HttpWebRequest)WebRequest.Create( ResolveUrl("~/default.aspx"));
    httpWebRequest.ContentType = "text/json";
    httpWebRequest.Method = "POST";
    string json = .... //Constrtuct your json here
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
    var response = httpWebRequest.GetResponse();
