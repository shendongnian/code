    class Program
    {
        static void Main(string[] args)
        {
            string mappingAddress = "EmployeeAddress.ChildAddressType.TheAddressType";
            string theAddressTypeValue = "A Home";
            Employee employee = new Employee();
            //Magic code - Thanks Jon Skeet
            SetProperty(mappingAddress, employee, theAddressTypeValue);
        }
        public static void SetProperty(string compoundProperty, object target, object value)
        {
            string[] bits = compoundProperty.Split('.');
            for (int i = 0; i < bits.Length - 1; i++)
            {
                PropertyInfo propertyToGet = target.GetType().GetProperty(bits[i]);
                target = propertyToGet.GetValue(target, null);
            }
            PropertyInfo propertyToSet = target.GetType().GetProperty(bits.Last());
            propertyToSet.SetValue(target, value, null);
        }
    }
    public class Employee
    {
        public Employee()
        {
            EmployeeAddress = new Address();
        }
        public Address EmployeeAddress { get; set; }
    }
    public class Address
    {
        public Address()
        {
            ChildAddressType = new AddressType();
        }
        public AddressType ChildAddressType { get; set; }
    }
    public class AddressType
    {
        public string TheAddressType { get; set; }
    }
