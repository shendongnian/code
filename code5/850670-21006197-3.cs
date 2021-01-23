    class Program
        {
            static void Main(string[] args)
            {
                Configuration.PropertyChanged += (sender, e) =>
                {
                    Menu.showMenu();
                };
                int choice;
    
                while (true)
                {
                    Menu.showMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
    
                    switch (choice)
                    {
                        case 1:
                            Configuration.Message = "HELLO!";
                            break;
    
                        case 2:
                            Configuration.Message = "HI!";
                            break;
    
                        case 3:
                            Configuration.Message = "WHAT?!";
                            break;
                    }
                }
            }
        }
    
        class Menu
        {
            public static void showMenu()
            {
                Console.Clear();
                Console.WriteLine("1: SOMETHING");
                Console.WriteLine("2: SOMETHING");
                Console.WriteLine("3: SOMETHING");
                Console.WriteLine("SYSTEM MSG: " + Configuration.Message);
                Console.Write("INPUT: ");
            }
        }
    
        public static class Configuration 
        {
            public static event PropertyChangedEventHandler PropertyChanged;
    
            private static string _message;
            public static string Message
            {
                get
                {
                    return _message;
                }
                set
                {
                    if (value != _message)
                    {
                        _message = value;
                        NotifyPropertyChanged(property: _message);
                    }
                }
            }
    
            private static void NotifyPropertyChanged(object property, String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(property, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
