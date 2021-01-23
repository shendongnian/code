    internal interface IVet<in T> where T : Animal
    {
        void Set(T animal);
        void Heal();
    }
    class Animal
    {
        public virtual void Examine(){Console.WriteLine("Animal");}
    }
    class Cat : Animal
    {
        public override void Examine(){Console.WriteLine("Cat");}
    }
    
    internal class Vet<T> : IVet<T> where T : Animal
    {
        private T _value;
        public void Set(T animal)
        {
            _value = animal;
        }
        public void Heal()
        {
            _value.Examine();
        }
    }
