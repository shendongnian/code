    public class UserDto : UserDomain
    { }
    public class UserDomain
    { }
    void YourMethod()
    {
         Expression<Func<UserDto, bool>> expression = new ExpressionSerializer().Deserialize<Func<UserDto, bool>>(xmlElement);
         Func<UserDto, bool> func = expression.Compile();
         Expression<Func<UserDomain, bool>> newExpression = x => func(x as UserDto);
         var addressBookEntries = addressBooksRepository.Where(newExpression);
    }
