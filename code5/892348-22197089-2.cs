    public IList GetReferenceDataByType(string referenceType)
    {
            // this works and returns the appropriate type correctly
            var type = this.GetEntity(referenceType); 
    
            var method = this.GetType().GetMethod("GetReferenceData");
            var generic = method.MakeGenericMethod(type);
            return (IList) generic.Invoke(this, new object[] { null });
    }
