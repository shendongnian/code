    public class Algorithm
    {
        private Algorithm()
        {
        }
    
        public void SomeMethod()
        {
        }
    }
    
    public static class Factory
    {
        public static Algorithm Create()
        {
            var constructor = typeof(Algorithm).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            return (Algorithm)constructor.Invoke(null);
        }
    }
