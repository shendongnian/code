    public class UserWithCreatedBy
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        [ForeignKey( "CreatedById" )]
        public UserWithCreatedBy CreatedBy { get; set; }
    }
    static void Main( string[] args )
    {
        using( var db = new TestContext() )
        {
            var u = new UserWithCreatedBy();
            // doesn't work with identity
            //u.CreatedBy = u;
            // this will work as long as you know what the identity seed is
            // (whatever the next identity value will be)
            u.CreatedById = 1;
            db.UsersWithCreatedBy.Add( u );
            db.SaveChanges();
        }
    }
