        UserType1 user1 = new UserType1
            {
                Id = 1,
                First = "John",
                Last = "Doe",
                Genter = Gender.Male,
                Created = DateTime.Now.AddDays(-1),
                Updated = DateTime.Now,
                DontMatchType = "won't map",
                Unique1 = "foobar"
            };
        UserType2 user2 = CopyTo<UserType2>(user1);
