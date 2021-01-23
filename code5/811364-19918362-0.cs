    static int? val;
    get{ 
        if (var.HasValue)
        {
          return val.Value;
        }
        else {
           val = GetValFromConfig();
           return val.Value;
        }
    } 
