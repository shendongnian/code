    var dictionary =  new Dictionary<string, string>();
    foreach (var key in Request.Params.AllKeys)
    { 
         if (key.ToString().Contains("txt"))
         {
              //get the text after "txt"
              var index = Request.Params[key].LastIndexOf("txt");
              var val = Request.Params[key].SubString(index);
              Dictionary.Add(key, val);
         }
    }
