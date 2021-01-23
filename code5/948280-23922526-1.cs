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
            Debug.WriteLine("Animal");
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
             Debug.WriteLine("Snake");
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
    Snake moved = snake.Move(); // "Snake"
    Animal animal = snake;
    animal.Move() // "Snake"
