    public class Base<T> where T : BaseDef
    {
        public T def;
    }
    public class A<T> : Base<T> where T : ADef
    {
    }
    public class B : A<BDef>
    {
        public int GetBar()
        {
            return def.bar;
        }
    }
