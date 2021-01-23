            MilkManDTO milkMan = await db.tblMilkMen.Select(b => new MilkManDTO()
            {
                RecordID = b.RecordID,
                UserID = b.UserID,
                IsMyTurn = b.IsMyTurn,
                RoundRobinOrder = b.RoundRobinOrder,
                User = new UserDTO {
                   UserID = b.User.UserID,
                   FirstName = b.User.FirstName,
                   LastName = b.User.LastName,
                } 
            }).SingleOrDefaultAsync(b => b.RecordID == id);
