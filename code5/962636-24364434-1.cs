    public class GoodFoo: ICloneable<GoodFoo>
    {
        public virtual GoodFoo Clone()
        { 
            return new GoodFoo();
        }
    }
    public class BadFoo: ICloneable<object>
    {
        public object Clone()
        {
            return new object();
        }
    }
    public class AlsoBad: GoodFoo
    {
        public override GoodFoo Clone()
        {
            return new GoodFoo();
        }
    }
