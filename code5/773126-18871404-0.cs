    public class Persistent
    {
        public virtual Persistent Clone() { return null; }
    }
    public class Animal : Persistent<Animal>
    {
        public override Animal Clone() { return null; }
    }
    public class Persistent<T>
    {
        public virtual T Clone() { return default(T); }
    }
    public class Animal : Persistent<Animal>
    {
        public override Animal Clone() { return null; }
    }
    public class Pet : Animal
    {
        public new Pet Clone()
        {
            return null;
        }
    }
