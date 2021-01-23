       public class UserCollection : Collection<User>
        {
            public IEnumerable GetAll()
            {
                return this.AsEnumerable();
            }
    
            public void MyFutureMethod()
            {
                //something you might want to do later on :-)
            }
        }
