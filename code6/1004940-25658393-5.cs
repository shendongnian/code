     List<Item> OldNews = (List<Item>)ListBox.DataSource;
     int newUniqueNewsCount = 0;
     foreach ( Item newObj in news ) // loop through new items that you just got as update from server
     {
          bool IsOld = false;
          foreach ( Item obj in OldNews) // loop through old items
          {
               if(obj.guid==objNew) //check if this GUID already existed
               {
                   IsOld = true;
                   break; //end the looping
               }
          }
          if(!IsOld)
          {
               // If code ran in here then this GUID is new and then this news is new so +1
               newUniqueNewsCount ++;
          }
     }
