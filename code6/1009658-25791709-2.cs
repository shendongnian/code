    class Car : INamedThing {
        public string Name { get; set; }
        public void Hello() {
            Console.WriteLine("This is a car, name is {0}", this.Name);
        }
    }
