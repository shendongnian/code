    class MyArrayClass {
        private Animal[] animals = {new Animal(1.1, 1.1), new Animal(2.2, 2.2)}
        public Animal this[int index] {
            get { return animals[index]; }
            set { animals[index] = value; }
        }
    }
