    public class DataTableMultiSort<T> where T : IdentityEntity
    {
    ...
        protected virtual Expression<Func<T, string>> GetOrderingFunc(int ColumnIndex)
        {
            return null;
        }
    }
    public class UserMultiSort : DataTableMultiSort<User>
    {
        protected override Expression<Func<User, string>> GetOrderingFunc(int ColumnIndex)
        {
            Expression<Func<User, string>> InitialorderingFunction;
            ...
         }
    }
