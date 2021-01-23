        class Visitor
        {
            public void Visit(Bar1 foo)
            {
                Console.WriteLine("Bar1 ID:" + foo.Id);
            }
            public void Visit(Bar2 foo)
            {
                Console.WriteLine("Bar2 ID:" + foo.Id);
            }
            public void Visit(Bar3 foo)
            {
                Console.WriteLine("Bar3 ID:" + foo.Id);
            }
        }
