    abstract class Animal<TConcrete> : IMovable<TConcrete, int>
    where TConcrete : Animal<T>
    {
        public virtual T Move(IMover<int> moverProvider) {
            return (T)this; // Cast to Animal<T> to T isn't implicit
        }
    }
    
    sealed class Snake : Animal<Snake>
    {
        public virtual Snake Move(IMover<int> moverProvider) {
            return this;
        }
    }
