            PizzaContext context = new PizzaContext();
            Pizza veggiDelite = new Pizza { Name = "Veggi Delite" };
            Topping pineapple = new Topping { Name = "Pineapple" };
            Topping chicken = new Topping { Name = "Chicken" };
            Pizza supremeChickenPizza = new Pizza { Name = "Supreme Chicken Pizza" };
            veggiDelite.PizzaToppings = new Collection<Topping> { new Topping { Name = "Jalepeeno" }, pineapple };
            supremeChickenPizza.PizzaToppings = new Collection<Topping> { pineapple };
            chicken.PizzasOn = new Collection<Pizza> { supremeChickenPizza };
            context.Pizzas.Add(veggiDelite);
            context.Toppings.Add(chicken);
            context.SaveChanges();
            foreach (Topping topping in context.Pizzas.SelectMany(p => p.PizzaToppings))
            {
                Console.WriteLine(topping.Name);
            }
            Console.ReadLine();
