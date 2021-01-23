    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //... more properties.
        public virtual ICollection<UserData> UserData { get; set; }
    }
    public class UserData
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
