    using (var db = dataBase())
    {
        var a = new user(); 
         .... 
         //set properties etc..
         ...
        a.myFavorits.Add(new BE.FavoritsUsersLong { myLong = f });
        db.users.Add(a);
        db.SaveChanges(); 
    }
