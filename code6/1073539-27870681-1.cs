        public class MyClass
        {
    
            [MyExceptionAspect(AspectPriority = 1)]
            [MyInterceptorAspect(AspectPriority = 2)]
            public string Do()
            {
                return "LOVE";
            }
        }
