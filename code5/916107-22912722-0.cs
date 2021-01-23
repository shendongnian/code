    var dictionary =  new Dictionary<string, string>();
     foreach (var key in Request.Params.AllKeys)
     { 
          if (key.ToString().Contains("txt"))
          {
             // add to dictionary name and value
             dictionary.Add(key.Split("txt")[1], Request.Params[key]);
          }
     }
