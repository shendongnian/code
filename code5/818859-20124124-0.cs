    List<BoAssetSecurityUser> userList = new List<BoAssetSecurityUser>();
    using (var context = DataObjectFactory.CreateContext())
    {
        var query = from ui in context.User_Information
                    where (ui.AssetCustomerID == 1 && (ui.GlobalID != "1TPTEMPUSER" || ui.GlobalID == null))
                    select new
                    {
                        ui.UserID,
                        ui.FirstName,
                        ui.LastName,
                        ui.Username,
                        ui.GlobalID
                    };
        foreach (var user in query)
        {
            BoAssetSecurityUser boAssetSecUser = new BoAssetSecurityUser();
            boAssetSecUser.UserId = user.UserID;
            boAssetSecUser.FirstName = user.FirstName;
            boAssetSecUser.LastName = user.LastName;
            boAssetSecUser.UserName = user.Username;
            boAssetSecUser.GlobalId = user.GlobalID;
            userList.Add(boAssetSecUser);
        }
    }
    return userList;
