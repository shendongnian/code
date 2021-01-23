    /// <summary>
    /// Marks a property as non-editable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NonEditableAttribute : Attribute
    {
    }
