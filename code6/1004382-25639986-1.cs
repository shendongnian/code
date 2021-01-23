    [DataContract]
    public abstract class BaseObject
    {
        public IPropertyChangeHelper propertyChangeHelper { get; set; }
        
        ...
    
        public void ChangeProperty<T>(
            ref T property,
            T value,
            string propertyName)
        {
            if (propertyChangeHelper != null)
               propertyChangeHelper.beforeChange(value, propetyName)
            ...
    
            if (propertyChangeHelper != null)
               propertyChangeHelper.afterChange(value, propetyName)
        }
    }
