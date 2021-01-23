    public class DataRecordDynamicWrapper : DynamicObject, ICustomTypeDescriptor
    {
        private IDataRecord _dataRecord;
        private PropertyDescriptorCollection _properties;
        //
        // (existing members)
        //
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            if (_properties == null)
                _properties = GenerateProperties();
            return _properties;
        }
        private PropertyDescriptorCollection GenerateProperties()
        {
            var count = _dataRecord.FieldCount;
            var properties = new PropertyDescriptor[count];
            for (var i = 0; i < count; i++)
            {
                properties[i] = new DataRecordProperty(
                    i,
                    _dataRecord.GetName(i),
                    _dataRecord.GetFieldType(i));
            }
            
            return new PropertyDescriptorCollection(properties);
        }
        
        //
        // (implement other ICustomTypeDescriptor members...)
        //
        private sealed class DataRecordProperty : PropertyDescriptor
        {
            private static readonly Attribute[] NoAttributes = new Attribute[0];
            private readonly int _ordinal;
            private readonly Type _type;
            public DataRecordProperty(int ordinal, string name, Type type)
                : base(name, NoAttributes)
            {
                _ordinal = ordinal;
                _type = type;
            }
            public override bool CanResetValue(object component)
            {
                return false;
            }
            public override object GetValue(object component)
            {
                var wrapper = ((DataRecordDynamicWrapper)component);
                return wrapper._dataRecord.GetValue(_ordinal);
            }
            public override void ResetValue(object component)
            {
                throw new NotSupportedException();
            }
            public override void SetValue(object component, object value)
            {
                throw new NotSupportedException();
            }
            public override bool ShouldSerializeValue(object component)
            {
                return true;
            }
            public override Type ComponentType
            {
                get { return typeof(IDataRecord); }
            }
            public override bool IsReadOnly
            {
                get { return true; }
            }
            public override Type PropertyType
            {
                get { return _type; }
            }
        }
    }
