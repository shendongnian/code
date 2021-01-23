    public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Type);
            HasMany(x => x.Videos).KeyColumn("keyColumn");
        }
    public VideoMap()
    {
        Id(x => x.VideoId);
        Map(x => x.UserId);
        Map(x => x.VideoTypeId);
        Map(x => x.Status);
        Map(x => x.Image);
        References(x => x.User).Column("keyColumn");
    }
