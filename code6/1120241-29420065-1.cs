    public class Person
    {
        private string name { get; set; }
        private int age { get; set; }
    
        public Person()
        {
    
        }
    
        public Person(IDictionary<string,object> data)
        {
            foreach (var value in data)
            {
                // The following line will be case sensitive.  Do you need to standardize the case of the input dictionary before getting the property?
                PropertyInfo property = typeof(Person).GetProperty(value.Key, BindingFlags.Instance | BindingFlags.NonPublic);
                if (property != null)
                {
                    property.SetValue(this, value.Value); // You are allowing any old object to be set here, so be prepared for conversion and casting exceptions
                }
                else
                {
                    // How do you want to handle entries that don't map to properties?  Ignore?
                }
            }
        }
    }
