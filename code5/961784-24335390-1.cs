    public class Foo
    {
        public virtual int GetGlobalStaticValue
        {
            return GlobalState.StaticValue;
        }
        public virtual int Bar(int baz)
        {
            return baz + this.GetGlobalStaticValue();
        }
    }
