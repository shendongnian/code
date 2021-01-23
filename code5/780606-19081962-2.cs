    using (var c = new WebClient())
    {
        var myNameValueCollection = new NameValueCollection();
            // Add necessary parameter/value pairs to the name/value container.
        myNameValueCollection.Add("token", "token");
        myNameValueCollection.Add("email", "email");
        myNameValueCollection.Add("password", "password");
        byte[] responseArray = c.UploadValues("MyServer/MyMethod", "POST", myNameValueCollection);
        return Encoding.ASCII.GetString(responseArray);
    }
