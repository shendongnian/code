    using (basecampcoreEntities dbs = ConfigAndResource.BaseCampContext())
    {
      //loads all user where isactive property has the same value as IsActive
      var Users = db.Users.Where(x => x.useraccount.IsActive == IsActive);
    
      if (Users.Any())
      {
        var searchText = SearchText.ToUpper();
        switch (SearchBy)
        {
          case DTO::SearchBy.FirstName:
            Users = Users.Where(item => item.FirstName.ToUpper() == searchText);
            break;
          case DTO::SearchBy.LastName:
            Users = Users.Where(item => item.LastName.ToUpper() == searchText);
            break;
          case DTO::SearchBy.LoginID:
            Users = Users.Where(item => item.LoginID.ToUpper() == searchText);
            break;
       }
       // apply sort and skip/take
       Users = Users.OrderBy(x => x.useraccount.CreateDate).Skip(skip).Take(take);
       //transform the data into DTO class
       return (from item in Users 
               select new DTO::User
               {
                  LoginID = item.LoginID,
                  FirstName = item.FirstName,
                  LastName = item.LastName,
                  MiddleName = item.MiddleName,
                  Birthday = item.userinfo != null ? item.userinfo.Birthday : DateTime.UtcNow
               }).ToList();
        }
        return null;
    }
