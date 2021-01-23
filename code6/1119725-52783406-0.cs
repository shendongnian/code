    [TestCaseSource((typeof(AccountTypes))]
    public void Get_Test_Result(string[] contactTypes)
    {
    }
    public class AccountTypes : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "ACCOUNT", "SOCIAL" };
        }
    }
