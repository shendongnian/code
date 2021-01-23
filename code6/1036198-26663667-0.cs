    public class MyUserStore : UserStore<MyUser>
    {
        public MyUserStore(DbContext context) : base(context)
        {
        }
    
        public override MyUser FindByName(string userName)
        {
            return Users.Include(x=>x.AddressType).Include(x=>x.Country).FirstOrDefault(n=>n.UserName == userName); 
            //you may need to also include the following includes if you need them
            //.Include(x=>x.Roles).Include(x=>x.Claims).Include(x=>x.Logins)
        }
    }
