    public interface IMovable<TEntity, T>
        where TEntity : class
        where T : struct
    {
        void MoveTo(IMover<T> moverProvider);
    }
    
    public abstract class Animal : IMovable<Animal, int>
    {
        public virtual void MoveTo(IMover<int> mover) { }
    }
    
    public static class AnimalExtensions
    {
        public static TAnimal Move<TAnimal>(this TAnimal animal, IMover<int> mover) where TAnimal : Animal, IMovable<TAnimal, int>
        {
            animal.MoveTo(mover);
            return animal;
        }
    }
