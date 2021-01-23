    public class Person {
        private const int DEFAULT_AGE = 18;
        private int _age = DEFAULT_AGE;
        [DefaultValue(DEFAULT_AGE)]
        public int Age {
            get { return _age; }
            set { _age = value; }
        }
    }
