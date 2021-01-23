       public class Menu
       {
          public MainMenu MainMenu{get;set;}
       }
        public class MainMenu
        {
            
            public List<string> Meal {get; set;}
    
            public MainMenu()
            {
                Meal = new List<string>();
            }
        }
