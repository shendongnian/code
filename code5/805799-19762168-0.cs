        class base1
        {
            protected string name { get; set; }
            public base1() { }
        }
        class child1 : base1
        {
            private string name = "";
            public void show()
            {
                base.name = "Daddy";
                this.name = base.name;
                Console.WriteLine("base name" + base.name);
                Console.WriteLine("child's name" + name);
            }
        }
