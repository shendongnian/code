        //This part adds the fields to the custom type, include near where the dictionary keys are being added as fields
        foreach (FieldInfo FI in InputObject.GetType().GetFields()) {
            if (FI.FieldType.IsPrimitive || FI.FieldType == typeof(string)) {
                FieldInfo fi = newInstance.GetType().GetField(FI.Name);
                fi.SetValue(newInstance, FI.GetValue(InputObject));
            }
        }
        
        //This part adds the values to the object, include near where the values are being set
        foreach (FieldInfo FI in InputObject.GetType().GetFields()) {
            if (FI.FieldType.IsPrimitive || FI.FieldType == typeof(string)) {
                FieldBuilder fieBuilder = typBuilder.DefineField(FI.Name, FI.FieldType, FieldAttributes.Public);
            }
        }
         
