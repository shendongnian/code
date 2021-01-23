    public class SimpleClass
    {
        private int value;
        private bool valueSet;
        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
                this.valueSet = true;
            }
        }
        public bool ValueSet { get { return valueSet; } }
    }
