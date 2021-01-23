    interface IAnimalProcessor { // The visitor interface
        void Process(Cat cat);
        void Process(Dog dog);
        void Process(Animal animal);
    }
    class AnimalProcessor : IAnimalProcessor {
        ...
    }
    interface IProcessable {
        void Accept(IAnimalProcessor proc);
    }
    class Cat : IProcessable {
        public void Accept(IAnimalProcessor proc) {
            proc.Process(this); // Calls the Cat overload
        }
    }
    class Dog : IProcessable {
        public void Accept(IAnimalProcessor proc) {
            proc.Process(this); // Calls the Dog overload
        }
    }
    ...
    AnimalProcessor animalProcessor = new AnimalProcessor();
    foreach (IProcessable animal in animals) {
        animal.Accept(animalProcessor); // The animal will call back the right method of the proc
    }
