    var ListUsers = from user in context.Users
                join address in context.Addresses
                select new
                {
                    User = user,
                    Address = address
                } into users
                group users by new 
                {
                    user.Property1OtherthanID,
                    user.Property2OtherthanID,
                    ...
                    address.Property1OtherthanID,
                    address.Property2OtherthanID,
                    ...
                } into distinct
                select new
                {
                    FirstUserID = distinct.FirstOrDefault().User.ID,
                    UserIDs = distinct.Select(u => u.User.ID)
                }
