    [DataContract]
    public class MyObject: BaseObject
    {    
        protected virtual void ChangeProperty<T>(
            ref T property,
            T value,
            string propertyName)
        {
            // Do my own stuff
            base.ChangeProperty(property, value, propertyName);
        }
    }
