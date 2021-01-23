    public interface IDataSet
    {
        TypedRecordsCollection Records { get; }
        IEnumerable<IProperty> PropertiesToDisplay { get; } 
    }
    public class TypedRecordsCollection : ObservableCollection<RecordViewModel>, ITypedList
    {
        private PropertyDescriptorCollection _properties;
        
        public TypedRecordsCollection(IEnumerable<IRecord> records)
        {
            _properties = new PropertyDescriptorCollection(
                PropertiesToDisplay
                    .Select(prop => new CustomPropertyDescriptor(prop))
                    .ToArray());
            records.ForEach(rec => Items.Add(new RecordViewModel(rec, _properties)));
        }
    
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return _properties;
        }
     }   
     public interface IRecordViewModel : ICustomTypeDescriptor
     {
        object GetCellValue(IProperty property);
        void SetCellValue(IProperty property, object value);
     }
     
     public class RecordViewModel : CustomTypeDescriptor, IRecord
     {
        private IRecord _record;
        private PropertyDescriptorCollection _properties;
        
        public RecordViewModel(IRecord record, PropertyDescriptorCollection properties)
        {
            _record = record;
            _properties = properties;
        }
        
        public object GetCellValue(IProperty property)
        {
            return _record.GetValue(property);
        }
        
        public void SetCellValue(IProperty property, object value)
        {
            _record.SetValue(property, value);
        }
        
        public override PropertyDescriptorCollection GetProperties()
        {
            return _properties;
        }
     }
     
     public class CustomPropertyDescriptor : PropertyDescriptor
     {
        private IProperty _property;
        
        public CustomPropertyDescriptor(IProperty property)
            : base(GetCleanName(property.Name), new Attribute[0])
        {
            _property = property;
        }
        
        public override object GetValue(object component)
        {
            var recordViewModel = component as IRecordViewModel;
            if (recordViewModel != null)
            {
                return recordViewModel.GetCellValue(_property);
            }
            
            return null;
        }
        
        public override void SetValue(object component, object value)
        {
            var recordViewModel = component as IRecordViewModel;
            if (recordViewModel != null)
            {
                recordViewModel.SetCellValue(_property, value);
            }
        }
        
        private static string GetCleanName(XName name)
        {
            // need to return a XAML bindable string.. aka no "{}" or ".", etc.
        }
     }
