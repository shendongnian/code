    public class Persistent
    {
        protected virtual object CloneOverride()
        {
            return new Persistent();
        }
        public Persistent Clone()
        {
            return (Persistent)CloneOverride();
        }
    }
    public class Animal : Persistent
    {
        protected override object CloneOverride()
        {
            return new Animal();
        }
        public new Animal Clone()
        {
            return (Animal)CloneOverride();
        }
    }
    public class Pet : Animal
    {
        protected override object CloneOverride()
        {
            return new Pet();
        }
        public new Pet Clone()
        {
            return (Pet)CloneOverride();
        }
    }
