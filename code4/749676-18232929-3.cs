        class Parent
        {
            public void MethodA()
            {
                Console.WriteLine("Parent");
            }
        }
    
        class Child : Parent
        {
            public new void MethodA()
            {
                Console.WriteLine("Child");
            }
        }
