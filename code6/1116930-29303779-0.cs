        class ParentClass
        {
            public ParentClass(){
                Console.WriteLine("parent created");
            }
        }
        class ChildClass : ParentClass
        {
            public ChildClass()
            {
                Console.WriteLine("child created");
            }
        }
