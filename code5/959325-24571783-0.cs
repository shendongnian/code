        if (propertyInfo.PropertyType.IsEnum || propertyInfo.PropertyType == typeof(Boolean))
         {
               generator.Emit(OpCodes.Unbox_Any, reader.GetFieldType(i));
         }
         else
         {
             generator.Emit(OpCodes.Call, GetConverterMethod(propertyInfo.PropertyType));
         }
