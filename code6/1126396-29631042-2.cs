    namespace SomeNamespace
    {
        public enum InitialisationMode
        {
            UseDefaultValues,
            DoOtherThings
        }
        public class SomeGenericClass<T>
        {
        
            public SomeGenericClass(InitialisationMode initMode = InitialisationMode.UseDefaultValues)
            {
        
            }
        }
    }
