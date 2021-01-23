    class IPolite {
        void Hello();
    }
    
    class Dog : IPolite {
        public string Name { get; set; }
        public void Hello() {
            Console.WriteLine("This is a dog named {0}", this.Name);
        }
    }
