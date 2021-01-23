    class BoolEntry : BaseEntry
    {
        public bool ConcreteValue { get; protected set; }
    
        public override object Value
        {
            get
            {
                return this.ConcreteValue;
            }
        }
        public override void SetValue(object value)
        {
            this.ConcreteValue = (bool)value;        
        }
        public void SetValue(bool value)
        {
            this.ConcreteValue = value; 
        }
        public override void Display()
        {
            Console.WriteLine("Here is your bool: " + this.ConcreteValue.ToString());
        }
    }
