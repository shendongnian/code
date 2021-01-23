    public abstract class Base { }
    public class BaseImplA : Base { }
    public class BaseImplB : Base { }
    public class IDoStuff
    {
        public virtual bool DoStuff(Base b)
        {
            return true;
        }
    } 
