    NameValueCollection parameters = new NameValueCollection();
    parameters.Add("value1", "123");
    parameters.Add("value2", "xyz");
    oWeb.QueryString = parameters;
    var responseBytes = oWeb.UploadFile("http://website.com/file.php", "path to file");
    string response = Encoding.ASCII.GetString(responseBytes);
