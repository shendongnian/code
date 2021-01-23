    var n = DataContext.Context.Users
                       .Where(u=>DataContext.Context.UsersFriends
                                .Where(uf=>(uf.UserSendReqID == 2 ||
                                           uf.UserReceiveReqID == 2) && uf.IsAccepted)
                                .Any(uf=>uf.UserFriendID == u.userID))
                       .Select(u=> new {
                                     Name = u.FirstName + " " + u.LastName                                     
                                   });
