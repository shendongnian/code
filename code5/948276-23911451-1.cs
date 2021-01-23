    abstract class Animal : IMovable<Animal, int>
    {
        Animal IMovable<Animal, int>.Move(IMover<int> moverProvider) {
            return MoveCore(moverProvider);
        }
        protected virtual Animal MoveCore(IMover<int> moverProvider) {
            // Peform moving
            return this;
        }
    }
   
    class Snake : Animal
    {
        public Snake Move(IMover<int> moverProvider) {
            return (Snake)MoveCore(moverProvider);
        }
        protected override Animal MoveCore(IMover<int> moverProvider) {
            // Peform custom snake moving
            return this;
        }
    }
