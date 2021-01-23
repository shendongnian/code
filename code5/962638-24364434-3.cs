    public class GoodFoo: ICloneable<GoodFoo>
    {
        public virtual GoodFoo Clone()
        { 
            var result = new GoodFoo();
            Contract.Assume(result.GetType() == this.GetType());
            return result;
        }
    }
    public class BadFoo: ICloneable<object>
    {
        public object Clone()
        {
            return new object(); // warning : CodeContracts: ensures unproven: Contract.Result<object>().GetType() == this.GetType()
        }
    }
    public class AlsoBad: GoodFoo
    {
        public override GoodFoo Clone()
        {
            return new GoodFoo(); // warning : CodeContracts: ensures unproven: Contract.Result<object>().GetType() == this.GetType()
        }
    }
