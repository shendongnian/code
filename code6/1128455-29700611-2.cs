    public static readonly Expression<Func<MyUserDBObjects, MyUserDBObjects, MyCompositeDTO>> CompositeDtoProject = 
        (u1, u2) => 
            new MyCompositeDTO()
            {
                User1Forename = u1.Forename,
                User1Surname = u1.Surname,
                User2Forename = u2.Forename,
                User2Surname = u2.Surname
            };
