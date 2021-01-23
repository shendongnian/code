    public class WindowBase : Window
    {
        protected static int foo = 5;
        public int Foo
        {
            get
            {
                return foo;
            }
            set
            {
                foo = value;
            }
        }
    }
    public partial class Window1 : WindowBase
    {
        public Window1()
        {
            int bar = base.Foo;
            
        }
    }
    public partial class Window2 : WindowBase
    {
        public Window2()
        {
            int bar = base.Foo;
        }
    }
