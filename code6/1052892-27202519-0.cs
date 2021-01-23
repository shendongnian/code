     foreach(phones obj in myList)
      {
       if(obj.Id == pid)
        {
          if (featurename == "Name")
          {
             return obj.Name;
          }
          else if (featurename == "Price")
          {
             return obj.Price.ToString();
          }
          break;
        }
      }
