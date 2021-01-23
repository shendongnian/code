    public static class HelloFactory
    {
    
        public Type GetHelloType(HelloEnum theEnum)
        {
            Type type;
            switch (theEnum)
            {
                case HelloEnum.Type1:
                    type = typeof(Hello1);
                    break;
                case HelloEnum.Type2: job = typeof(Hello2);
                    break;
            }
    
        }
    }
