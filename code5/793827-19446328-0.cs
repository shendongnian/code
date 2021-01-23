    public class ExtraThing : Thing
    {
        public ExtraThing(Context c, IAttributeSet attrs)
             : base(c, attrs)
        {
        }
        protected override SomethingChanged()
        {
            MyPropertyChanged.Raise(this);
        }
        public PType MyProperty
        {
           get { return base.Something(); }
           set { base.ChangeSomething(value); }
        }
        public event EventHandler MyPropertyChanged;
    }
