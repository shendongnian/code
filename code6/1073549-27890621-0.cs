    public interface IAnimalFactoryProvider
        {
            IEnumerable&lt;IAnimalFactory&gt; GetAllAnimalFactories();
            void Release(IAnimalFactory animalFactory);
        }
