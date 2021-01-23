    User[] data = new User[] {
                new User(1, "first"),
                new User(1, "second"),
                new User(1, "third"),
                new User(2, "first"),
                new User(2, "second"),
                new User(2, "third"),
            };
            //Get all data with userID = 1
            User[] userID1 = data.Where(user => user.Id == 1).ToArray();
            //Get all data with userID = 2
            User[] userID2 = data.Where(user => user.Id == 2).ToArray();
