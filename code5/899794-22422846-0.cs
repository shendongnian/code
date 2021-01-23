        public delegate void MyFunctionExposed(string user, string pass);
        public static MyFunctionExposed functionMySQLCheckLogin;
        public Form1()
        {
            InitializeComponent();
            functionMySQLCheckLogin = CheckLogin;
        }
