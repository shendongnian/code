    public MyCustomUser : IUser
    {
       public string Id { get; set; }
    
       public string FavoriteHairColor { get; set;}
    }
    
    public ApplicationUser : IdentityUser
    {
         public virtual ICollection<MyCustomUser> MyCustomUsers{ get; set; }    
    }
