    public class AccountProcessor
    {    
        // ...
        public IEnumerable<int> GetAgesFrom(string file)
        {
            return _accountReader.GetAccountFrom(file).Where(x => x.Age);
        }
    }
