    public class ContainerSingleton
    {
        private static Lazy<CompositionContainer> compositionContainer;
    
        public static CompositionContainer ContainerInstance
        {
            get 
            {
                return compositionContainer.Value;
            }
        }
    
        public static ContainerSingleton()
        {
            compositionContainer = new Lazy<CompositionContainer>(() => Initialize());
        }
        public static void Initialize()
        {
             // Full initialization logic here
        }
    }
