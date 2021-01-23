    public class UserSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return !String.IsNullOrEmpty(user.Firstname) &&
                   !String.IsNullOrEmpty(user.Lastname) &&
                   !String.IsNullOrEmpty(user.Email) &&
                   !String.IsNullOrEmpty(user.Username);
        }
    }
