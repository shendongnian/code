    public partial class MyForm : Form
    {
      private static Object _mutex = new Object();
        private static  MyForm _instance = null;
        public static MyForm GetInstance(...params...)
        {
            if (_instance == null)
            {
                lock (_mutex)
                {
                    if (Ispostback)
                    {
                        _instance = new MyForm(..params..);
                    }
                }
            }
    
            return _instance;
        }
    }
