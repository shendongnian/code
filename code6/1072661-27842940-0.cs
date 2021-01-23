        foreach (var dbInterest in request.UserInterests){
          if(dbItem.Interests.Any()){
            if (dbItem.Interests.Count(i=> i.Name==dbInterest && i.UserId==dbItem.UserId) == 0){
              dbItem.Interests.Add(new DbUserInterest { Name = dbInterest, UserId = dbItem.UserId});
            }
          }
       }
