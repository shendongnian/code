    public class MyClass
    {
        private string _user;
        public string user
        { get { return this._user; } set { this._user = value; } }
    
    }
    public string YourFunction()
    {
       MyClass m = new MyClass();
       m.user = "abc"
       return m.user;
    }
