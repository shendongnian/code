    public abstract class Animal<T> : IMovable<T, int> where T:Animal<T>        
    {
        public virtual T Move(IMover<int> moverProvider)
        {
        ...
        }
    }
    public class Snake : Animal<Snake>
    {
        public override Snake Move(IMover<int> moverProvider)
        {
        ...
        }
    }
