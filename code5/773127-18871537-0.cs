    public abstract class Persistent<T>
    {
        protected abstract T CloneOverride();
        public T Clone()
        {
            return CloneOverride();
        }
    }
    public class Animal : Persistent<Animal>
    {
        protected override Animal CloneOverride()
        {
            return new Animal();
        }
        public new Animal Clone()
        {
            return CloneOverride();
        }
    }
    public class Pet : Persistent<Pet>
    {
        protected override Pet CloneOverride()
        {
            return new Pet();
        }
        public new Pet Clone()
        {
            return CloneOverride();
        }
    }
