    public class SomeViewModel<T> where T : IAnimal
    {
        public T Animal { get; set; }
        ...
    }
