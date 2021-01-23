    var dictionary =  new Dictionary<string, string>();
    foreach (var key in Request.Params.AllKeys)
    { 
         if (key.ToString().Contains("txt"))
         {
              int index = Request.Params[key].LastIndexOf("txt");
              Dictionary.Add(key, Request.Params[key].SubString(index));
         }
    }
