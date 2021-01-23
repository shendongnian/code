    // Get response
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        StreamReader reader = new StreamReader(response.GetResponseStream());
        //add your code here to customize the return value
        var array = Newtonsoft.Json.Linq.JArray.Parse(reader.ReadToEnd());
        var jObject = new Newtonsoft.Json.Linq.JObject();
        jObject.Add("Status", array[0].Value<string>("Status"));
        textResult.Text = jObject.ToString();
        
    }
