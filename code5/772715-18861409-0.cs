    public class Percent
    {
    
        public static implicit operator double(Percent p)
        {
            return p.Value;
        }
    
    
        private Percent() { }
    
        public Percent(double value)
        {
            this.Value = value;
        }
    
        double value;
    
        public double Value
        {
            get { return this.value; }
            set
            {
                if (!ValidateNewValue(value))
                    throw new ArgumentException(string.Format("The value '{0}' is not a valid.", value));
                this.value = value;
            }
        }
    
        protected virtual bool ValidateNewValue(double value)
        {
            return true;
        }
    }
    
    public class ValidPercent : Percent
    {
    
        public ValidPercent(double d)
            : base(d) { }
    
        protected override bool ValidateNewValue(double value)
        {
            return !(value > 100 || value < 0);
        }
    }
