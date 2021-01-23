        class TypeA : BaseClass {}
        class TypeB : BaseClass {}
        class BaseClass
        {
            public string Name { get; set; }
        }
        public enum Test
        {
            A = 0,
            B
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            const Test enumType = Test.A;
            Type myType = null;
            switch (enumType)
            {
                case Test.A:
                    myType = typeof(TypeA);                    
                    break;
                case Test.B:
                    myType = typeof(TypeB);                    
                    break;
            }
            var result = JsonConvert.DeserializeObject("{ 'Name': 'test' }", myType);
