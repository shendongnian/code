    abstract class Animal : IMovable<Animal, int>
    {
        // Please note that this implementation is explicit
        Animal IMovable<Animal, int>.Move(IMover<int> moverProvider) {
            return MoveThisAnimal(moverProvider);
        }
        protected virtual Animal MoveThisAnimal(IMover<int> moverProvider) {
            // Peform moving
            return this;
        }
    }
   
    class Snake : Animal
    {
        public Snake Move(IMover<int> moverProvider) {
            return (Snake)MoveThisAnimal(moverProvider);
        }
        protected override Animal MoveThisAnimal(IMover<int> moverProvider) {
            // Peform custom snake moving
            return this;
        }
    }
