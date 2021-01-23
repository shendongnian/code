    public abstract class DataFileBase<T>
    {
        protected abstract T BuildInstance(string[] tokens);
    }
    public AccountDataFile : DataFileBase<AccountDataFile.Account>
    {
        protected override Account BuildInstance(string[] tokens)
        {
            var account = new Account();
            account.Name = tokens[0]; // or whatever
            return account;
        }
    }
