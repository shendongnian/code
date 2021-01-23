    var dictionary =  new Dictionary<string, string>();
    foreach (var key in Request.Params.AllKeys)
    { 
         if (key.ToString().Contains("txt"))
         {
              //get the text after "txt"
              var value = Request.Params[key].Split("txt")[1]; 
              Dictionary.Add(key, value);
         }
    }
