    class MyClass {
        public MyClass(Counter counter) {
            // Myhahaha, your base belongs to me!
            counter.fireEvent = new ReachedEventHandler(reached); 
        }
        private void reached(object sender) {
            // etc...
        }
    }
