    public class Class1
    {
        private readonly IUserBLL _userBll;
    
        public Class1(IUserBLL userBll)
        {
            // Null checks here...
            _userBll = userBll;
        }
    
        public void Method!()
        {
            _userBll.DoSomething();
        }
    }
