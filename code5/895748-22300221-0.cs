        public abstract class TypeA
        {
            public class Description
            {
                public static String Name { get; set; }
            }
        }
        public class TypeB : TypeA
        {
            public string AccessToStaticMember { get; private set; }
            public TypeB()
            {
                AccessToStaticMember = Description.Name;
            }
        }
