        public static class Configuration
        {
            private static string _message;
            public static string Message 
            { 
                get
                {
                    return _message;
                }
                set
                {
                    _message = value;
                    Menu.showMenu();
                }
            }
        }
