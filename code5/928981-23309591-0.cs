    class Menu
    {
        public Menu()
        {
            CreateElementToMenu();
        }
    
        public List<Pizza> pizzaOnMenu = new List<Pizza>();
    
        public void CreateElementToMenu()
        { 
            pizzaOnMenu.Add(new Pizza(1, "Magarita", "Tomato, cheese", 49));
            pizzaOnMenu.Add(new Pizza(2, "Hawaii", "Tomato, cheese, ham, pineapple", 55));
            pizzaOnMenu.Add(new Pizza(3, "Cappriciossa", "Tomato, cheese, ham, mushroom", 55));
            pizzaOnMenu.Add(new Pizza(4, "Special", "Tomato, cheese, beef", 60));
        }
    }
