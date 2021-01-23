    public interface IObj
    {
        IObj Duplicate();
    }
    public abstract class Obj : IObj
    {
        public Obj()
        {
        }
        public virtual IObj Duplicate()
        {
            return this;
        }
    }
    public abstract class ObjT<T> : Obj
    {
        public ObjT()
        {
        }
        public override IObj Duplicate()
        {
            return this;
        }
    }
    public class ObjImpl : Obj
    {
    }
    public class ObjTImpl : ObjT<int>
    {
    }
