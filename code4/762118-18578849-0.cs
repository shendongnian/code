    public form MyForm : Form
    {
        Foo myFoo = new Foo(this)
    }
    public class Foo
    {
        private MyForm parentForm;
        public Foo(MyForm parent)
        {
            parentForm = parent;
        }
    }
