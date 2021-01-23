    public class DerivedClass : MyBaseClass
    {
        private int customSecondaryProp;
        private DateTime when;
        private void InitializeDerivedClass()
        {
            customSecondaryProp = 10;
            someValue = 5;
        }
        public DerivedClass()
        {
            InitializeDerivedClass();
        }
        public DerivedClass(object SomeParm): base(SomeParm)
        {
            InitializeDerivedClass();
            when = DateTime.Now;
        }
    }
