    public class MyContext
    {
        private MyUser _myUser;
    
        public static MyContext Current
        {
            get
            {
                if (HttpContext.Current.Items["MyContext"] == null)
                {
                    MyContext context = new MyContext();
                    HttpContext.Current.Items.Add("MyContext", context);
                    return context;
                }
                return (MyContext) HttpContext.Current.Items["MyContext"];
            }
            }
    
            public MyUser MyUser
            {
    
                get { return _myUser; }
                set { _myUser = value; }
            }
        }
    }
