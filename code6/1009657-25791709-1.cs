    class INamedThing {
        string Name { get; set; }
        void Hello();
    }
    
    class Dog : INamedThing {
        public string Name { get; set; }
        public void Hello() {
            Console.WriteLine("This is a dog named {0}", this.Name);
        }
    }
