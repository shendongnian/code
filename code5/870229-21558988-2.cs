    public abstract class CacheAction
    {
        //so it can't be inherited from elsewhere
        private  CacheAction() { }
        public class TypeA : CacheAction
        {
            private TypeA() { }
            public static readonly TypeA SomthingFromACache = new TypeA();
            public static readonly TypeA SomethingElseFromACache = new TypeA();
        }
        public class TypeB : CacheAction
        {
            private TypeB() { }
            public static readonly TypeB SomthingFromBCache = new TypeB();
            public static readonly TypeB SomethingElseFromBCache = new TypeB();
        }
    }
