    public class BaseClass
    {
        private MyType myField;
        protected BaseClass(MyType myField)
        {
            this.myField = myField;
        }
        public BaseClass() : this(new MyType())
        {
        }
    }
