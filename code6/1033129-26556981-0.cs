    public class ListingAttribute : AgencyServicesApi.Attribute
    {
        public Type ClrType { get; set; }
        
        public void SetValue(object value)
        {
            SetValueGen((dynamic)value);
        }
    
        public void SetValueGen<TValue>(TValue value)
        {
            var t = typeof(TValue);
            Value = // Use conversion methods based on ClrType here.
        }
    }
