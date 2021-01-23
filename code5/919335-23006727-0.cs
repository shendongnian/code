       var client = new WebClient();
       var stream  = client.OpenRead (url);
       var reader = new StreamReader (stream);
       string json = reader.ReadToEnd ();
       data.Close ();
       reader.Close ();
       // Deserialize json (supposing you are using package Newtonsoft.Json)
       var obj = JsonConvert.DeserializeObject(json);
