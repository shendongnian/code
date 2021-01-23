    public class Property
    {
        public virtual int Id { set; get; }
        public virtual PropertyKind Kind { set; get; }
        public PropertyValueType ValueType { set; get; }
        // not mapped
        public virtual object Value { ... some logic inside of the getter and setter }
    
        // mapped properties - could be protected and hidden from upper consumers
        protected virtual int?      IntValue      { get; set;}
        protected virtual string    StringValue   { get; set;}
        protected virtual double?   DoubleValue   { get; set;}
        protected virtual DateTime? DateTimeValue { get; set;}
    }
