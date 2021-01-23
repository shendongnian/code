    public abstract class BaseGeneric<T>
    {
        T data;
        // ctor
        protected BaseGeneric(T data)
        {
            this.data=data;
        }
        // methods
        public abstract void Update();
        // properties
        public T Data
        {
            get { return data; }
            set { data=value; }
        }
        // base nested class
        public abstract class BaseNested<B> where B : BaseGeneric<T>
        {
            protected B @base;
            // ctor
            protected BaseNested(B @base)
            {
                this.@base=@base;
            }
            // methods
            public abstract void Input(T data);
            public void Update() { @base.Update(); }
            // properties
            public T Data
            {
                get { return @base.data; }
                set { @base.data=value; }
            }
        }
    }
    // implementation base
    public class Base : BaseGeneric<int>
    {
        // ctor
        protected Base(int data) : base(data) { }
        //methods
        public override void Update()
        {
            this.Data+=1;
        }
        // implemented nested class
        public class Nested : Base.BaseNested<Base>
        {
            // ctor
            public Nested(int data) : base(new Base(data)) { }
            public Nested(Base @base) : base(@base) { }
            // methods
            public override void Input(int data)
            {
                this.Data=data;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // new implemented class with value 0
            var nested=new Base.Nested(0);
            // set value to 100
            nested.Input(100);
            // call update as implemented by `Base`.
            nested.Update();
        }
    }
