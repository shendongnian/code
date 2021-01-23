    var n = DataContext.Context.Users
                       .Join(DataContext.Context.UsersFriends
                                        .Where(uf=>(uf.UserSendReqID == 2 ||
                                           uf.UserReceiveReqID == 2) && uf.IsAccepted),
                             x=>x.userID, x=>x.UserFriendID, (x,y)=>x)
                       .Select(u=> new {
                                     Name = u.FirstName + " " + u.LastName                                     
                                   });
