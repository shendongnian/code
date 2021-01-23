    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CsvIgnoreAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CsvHeaderAttribute : Attribute
    {
        /// <summary>
        /// The name to use for the CSV column header
        /// </summary>
        public string Name { get; set; }
    }
