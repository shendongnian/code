    public class MyWrappedClass
    {
        public Boolean IsLoggedIn {get; private set;}
        private MyClass m_Log;
        public MyWrappedClass ()
	    {
            this.m_Log = new MyClass();
            this.IsLoggedIn = false;
	    }
    
        public void Log()
        {
              try
              {
                  this.m_Log.LogIn();
                  this.IsLoggedIn = true;
              }
              catch
              {
                  this.IsLoggedIn = false;
              }
        }
        public void LogOut()
        {
            try
            {
                this.m_Log.LogOut();
                this.IsLoggedIn = false;
            }
            catch
            {
                this.IsLoggedIn = true;
            }
        }
    }
