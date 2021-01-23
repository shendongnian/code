    public class BaseClass
    {
        public virtual string InstanceProperty
        {
            get { return StaticProperty; }
        }
        public static string StaticProperty
        {
            get { return "BaseClass"; }
        }
    }
    public class Derived1Base : BaseClass
    {
        public override string InstanceProperty
        {
            get { return StaticProperty; }
        }
        public new static string StaticProperty
        {
            get { return "Derived1Base"; }
        }
    }
    public class Derived1Derived1Base : Derived1Base
    {
    }
    public class Derived2Base : BaseClass
    {
        public override string InstanceProperty
        {
            get { return StaticProperty; }
        }
        public new static string StaticProperty
        {
            get { return "Derived2Base"; }
        }
    }
