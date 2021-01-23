        //Your functionality goes here
        public class UserManager : IUserManager
        {
            private Dictionary<int, User> Users = new Dictionary<int, User>();
            public override User this[int id]
            {
                get { return Users[id];}
            }
            public override IEnumerator<IUser> GetEnumerator()
            {
                return Users.Values.GetEnumerator();
            }
            public void Add(User user)
            {
                Users[user.Id] = user;
            }
        }
        //What the user can see goes here
        public abstract class IUserManager : IEnumerable<IUser>
        {
         
            public abstract User this[int id] { get; }
            public abstract IEnumerator<IUser> GetEnumerator();
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
