    class Example {
        private int instance;
        public Example(int instance) { this.instance = instance; }
        ~Example() {
            Console.WriteLine("Example {0} finalized", instance);
        }
    }
