    public class TestEntity : BindableBase
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        //Notice I've implemented the OnPropertyNotify (Prism uses SetProperty, but it's the same thing)
        private Int32 _count;
        public Int32 Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }
    }
