    using(var client = new WebClient()){
        var postData = new System.Collections.Specialized.NameValueCollection();
        postData.Add("name1", "val1");
        postData.Add("name2", "val2");
        byte[] response = client.UploadValues("http://www.somesite.com/someform.php", "POST", postData);
        var responsebody = Encoding.UTF8.GetString(response);
    }
