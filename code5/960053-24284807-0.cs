    public interface IFooAttempt2<out T>
        where T : IAnimal 
    {
        T Animal
        { 
            get; 
        }
    }
