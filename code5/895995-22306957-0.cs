    public class A
    {
        [Display(Name = "Initial Score Code", Order = 3)]
        public int Code
        {
            get;
            set;
        }
        [Display(Name = "Initial Score Code", Order = 2)]
        public string Name
        {
            get;
            set;
        }
    }
    public class PropertyInfoComparer : IComparer<PropertyInfo>
    {
        public int Compare(PropertyInfo x, PropertyInfo y)
        {
            var attribute1 = (DisplayAttribute)x.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();
            var attribute2 = (DisplayAttribute)y.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();
            // If the first property has no attribute, sort it first
            if (attribute1 == null)
            {
                return -1;
            }
            // If the second property has no attribute, sort it first
            if (attribute2 == null)
            {
                return 1;
            }
            // Compare the Order properties of both attributes
            return attribute1.Order.CompareTo(attribute2.Order);
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
        public int Order
        {
            get;
            set;
        }
    }
