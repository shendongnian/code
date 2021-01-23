    namespace global
    {
        // all things are within this namespace, and therefor
        // it is typically deduced by the compiler. only during
        // name collisions does it require being explicity
        // strong named
        
        public class TestApp
        {
        }
        namespace Program1
        {
            public class TestClass : global::TestApp
            {
                // notice how this relates to the outermost namespace 'global'
                // as if it were a traditional namespace.
                // the reason this seems strange is because we traditionally
                // develop at a more inner level namespace, such as Program1.
            }
        }       
    }
