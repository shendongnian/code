      for (int i = 0; i < Session.Contents.Count; i++)
     {
          var key = Session.Keys[i];
          var value = Session[i];
          
          //remove the key except one
          if(key!="youkey")
          {
               Session.Remove(key);
               i++;
           }
     }
