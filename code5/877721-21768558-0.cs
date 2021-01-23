    public class Derived : Base {
        public override void X(ParamX x) { }
        public override void X(ParamY a) { }
    }
    public abstract class Base : IXVisitor
    {
        public void Visit(IParametr parameter)
        {
            parameter.Accept(this);
        }
        public abstract void X(ParamX x);
        public abstract void X(ParamY a);
    }
    public interface IXVisitor
    {
        void X(ParamX a);
        void X(ParamY a);
    }
    public interface IParametr
    {
        void Accept(IXVisitor visitor);
    }
    public class ParamX : IParametr
    {
        public void Accept(IXVisitor visitor)
        {
            visitor.X(this);
        }
    }
    public class ParamY : IParametr
    {
        public void Accept(IXVisitor visitor)
        {
            visitor.X(this);
        }
    }
