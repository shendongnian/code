	System.Reflection.FieldInfo[] fields = obj.GetType().GetFields();
	foreach (System.Reflection.FieldInfo info in fields) {
		object fieldValue = info.GetValue(obj);
		if (fieldValue != null) {
			System.Type type = fieldValue.GetType();
			string s = System.ComponentModel.TypeDescriptor.GetConverter(
                type).ConvertToInvariantString(fieldValue);
            ...
		}
	}
