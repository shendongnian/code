    public abstract class ModelObject<T, DataCoreType, IDType> : INotifyPropertyChanged, IEditableObject
    {
        protected DataCoreType dataCoreBackup;
        public virtual void BeginEdit() {
            Type t = typeof(T);
            
            // get a the properties with the attribute
            var props = t.GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(DataCoreMemberAttribute)));
    
            // backup needs to be boxed because it's a struct
            object boxedBackup = this.dataCoreBackup;
            foreach (var prop in props) {
                foreach (CustomAttributeData attribData in prop.GetCustomAttributesData()) {
                    if (attribData.Constructor.DeclaringType == typeof(DataCoreMemberAttribute)) {
                        
                        object origValue = prop.GetValue(this);
                        FieldInfo field = boxedBackup.GetType().GetField(attribData.NamedArguments[0].TypedValue.Value.ToString());
                        field.SetValue(boxedBackup, origValue);
                    }
                }
            }
            this.dataCoreBackup = (DataCoreType)boxedBackup;
            IsEditing = true;
        }
