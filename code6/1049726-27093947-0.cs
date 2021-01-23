    var friendsList = dbContext.AspNetUsers
                      .AsEnumerable()
                      .Where(u.Id != currentUserId && !u.Friends
                                                         .Select(f=>f.UserFriendId)
                                                         .AsEnumerable()
                                                         .Contains(currentUserId))
                      .ToList();
