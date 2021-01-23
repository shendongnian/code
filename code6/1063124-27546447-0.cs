    public class Base
    {
        public Prop prop { get; set; }
    }
    public class Derived : Base
    {
        // some other properties of the derived class , not so relevant....
    }
    public class Prop
    {
        public String propString { get; set; }
    }
    public class MyClass
    {
        public void SecondFunc(object obj)
        {
            Type type = obj.GetType();
            var allClassProperties = type.GetProperties();
            foreach (var propertyInfo in allClassProperties)
            {
                if (propertyInfo.PropertyType == typeof(Prop))
                {
                    var pVal = (Prop)propertyInfo.GetValue(obj, null);
                    if(pVal == null)
                    {
                        //creating a new instance as the instance is not created in the ctor by default
                        pVal = new Prop();
                        propertyInfo.SetValue(obj, pVal, null);
                    }
                    this.SecondFunc(pVal);
                }
                else if (propertyInfo.PropertyType == typeof(string))
                {
                    string value = (string)propertyInfo.GetValue(obj, null);
                    string afterRemovalValue = myManipulationStringFunc(value);
                    propertyInfo.SetValue(obj, afterRemovalValue, null);
                }
            }
        }
        private string myManipulationStringFunc(string value)
        {
            if (string.IsNullOrEmpty(value))
                value = "Value was NULL";
            return value;
        }
    }
