        if (originalDelta.GetChangedPropertyNames().Contains("ModifiedDate"))
        {
            return InternalServerError(new ArgumentException("Attribue is read-only", "ModifiedDate"));
        }
 
 
