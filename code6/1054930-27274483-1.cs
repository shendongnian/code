    public UserMap()
    {
        Table("User");
        Id(x => x.Id).GeneratedBy.GuidComb();
        LazyLoad();
        References(x => x.Role).Column("Role");
        Map(x => x.Username).Column("Username");
        Map(x => x.PasswordHash).Column("PasswordHash").Not.Nullable();
        Map(x => x.Salt).Column("Salt").Not.Nullable();
        Map(x => x.Token).Column("Token").Not.Nullable();
        Map(x => x.TokenStamp).Column("TokenStamp");
    }
