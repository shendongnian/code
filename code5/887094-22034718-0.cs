    ...
        [Serializable]
        public class Test2():Test1
        {
            [Obsolete("Don't use the default constructor.", true)]
            public Test2():base()
            {
        
            }
    ...
