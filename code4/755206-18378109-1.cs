    public class UserService: IUser
    {
        public User AddUser(User user)
        {
            try
            {
                IUserRepository _user = new UserRepository(); //I've used EF Repository Pattern.
                return _user.Add(user);
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException<ValidationFault>(new ValidationFault(), ex.Message);
            }
        }
    }
