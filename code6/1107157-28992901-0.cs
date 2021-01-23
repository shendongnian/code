    void Main()
        {
            ILivingThing<Appendage> mysteryAnimal = new Cat();
        }
        public class Appendage { }
        public class Paw : Appendage { }
        public interface ILivingThing<out TExtremity> where TExtremity : Appendage { }
        public class Animal<TExtremity> : ILivingThing<TExtremity> where TExtremity : Appendage { }
        public class Cat : Animal<Paw> { }
