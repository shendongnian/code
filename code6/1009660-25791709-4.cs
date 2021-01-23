    class Animal {
        public string Name { get; set; }
        public abstract void Hello();
    }
    
    class Dog : Animal {
        public override void Hello() {
            Console.WriteLine("This is a dog named {0}", this.Name);
        }
    }
