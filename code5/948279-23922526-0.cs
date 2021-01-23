    public interface IMovable
    {
        IMovable MoveFunc();
    }
    public interface IMovable<TEntity, T> : IMovable
        where TEntity : IMovable
    {
        new TEntity MoveFunc();
    }
    public abstract class Animal : IMovable<Animal, int>
    {
        protected virtual Animal MoveFunc()
        {
            // performs movement using provided mover
        }
        Animal IMovable<Animal, int>.MoveFunc()
        {            
            return MoveFunc();
        }
        IMovable IMovable.MoveFunc()
        {
            return ((IMovable<Animal, int>)this).MoveFunc();
        }
    }
    public class Snake : Animal
    {
        protected override Animal MoveFunc()
        {
             // performs movement using provided mover
        }
    }
    public static class IMovableExtensions
    {
        public static TOut Move<TOut>(this TOut entity) where TOut : IMovable
        {
            return (TOut)entity.MoveFunc();
        }
    }
    ...
    Snake snake = new Snake();
    Snake moved = snake.Move(); //no cast required
    Animal animal = snake;
    List<Animal> animals = new List<Animal>{snake, animal};
