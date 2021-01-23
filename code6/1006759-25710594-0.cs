           class SomethingElse_class : SomethingElse
            {
                public void g(Something_class s)
                {
                    Console.WriteLine("SomethingElse.g");
                }
                public void g(Something s) //overload g with the (Something s)
                {
                    Console.WriteLine("Something.g");
                }
            }
