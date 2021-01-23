    public class CustomList<T> : List<T>
    {
        static CustomList()
        {
            TypeDescriptor.AddAttributes(typeof(CustomList<T>), new TypeConverterAttribute(typeof(ExpandableCollectionConverter)));
        }
    }
