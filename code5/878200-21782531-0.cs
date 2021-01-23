    public ObservableCollection<T> GetObservableCollectionFor(object sObject)
    {
    
       Type wantedType = sObject.GetType();
    
       foreach (PropertyInfo info in this.GetType().GetProperties())
       {
    
         if (info.GetGetMethod() != null && info.PropertyType == typeof(ObservableCollection).MakeGeneric(new[]{Type.GetType(wantedType)})
            return this.GetType().GetProperty(info.Name).GetValue(this, null);
    
       }
    
       return null;
    
    }
