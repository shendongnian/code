    internal sealed class MyCustomTypeDescriptor : CustomTypeDescriptor
    {
        public MyCustomTypeDescriptor(ICustomTypeDescriptor parent)
            : base(parent)
        {
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return AddItems(base.GetProperties(attributes),
                new FieldPropertyDescriptor<MyFieldsClass, int>("IntField"),
                new FieldPropertyDescriptor<MyFieldsClass, double>("DoubleField"));
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return AddItems(base.GetProperties(),
                new FieldPropertyDescriptor<MyFieldsClass, int>("IntField"),
                new FieldPropertyDescriptor<MyFieldsClass, double>("DoubleField"));
        }
        private static PropertyDescriptorCollection AddItems(PropertyDescriptorCollection cols, params PropertyDescriptor[] items)
        {
            PropertyDescriptor[] array = new PropertyDescriptor[cols.Count + items.Length];
            cols.CopyTo(array, 0);
            for (int i = 0; i < items.Length; i++ )
                array[cols.Count + i] = items[i];
            PropertyDescriptorCollection newcols = new PropertyDescriptorCollection(array);
            return newcols;
        }
    }
