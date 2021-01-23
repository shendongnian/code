        private static void navelGaze(string name, int level, ref object val, int storageSize)
        {
            Debug.Assert(val != null); // can happen with an unitialized string (please init to "")
            Type t = val.GetType();
            StringBuilder diagString = new StringBuilder(100);
            diagString.Append(name); diagString.Append(": ");
            if (t.IsArray)
            {
                Type t_item = t.GetElementType();
                Array ar = val as Array;
                int len = ar.Length;
                diagString.Append("Type="); diagString.Append(t_item.Name);
                diagString.Append("["); diagString.Append(len); diagString.Append("]");
                if (t_item.BaseType.Name == "ValueType")
                {
                    // array of primitive types like Bool or Int32...
                    diagString.Append(", value=[");
                    // Because C# does not permit modification of the iteration object
                    // in "foreach", nor subscript operations on an array of primitive values,
                    // use "GetValue/Setvalue" and a regular index iteration.
                    for(int idx=0; idx<len; idx++) {
                        object arrayElementBoxObj = ar.GetValue(idx);
                        Munger(ref arrayElementBoxObj, 0);
                        diagString.Append(arrayElementBoxObj.ToString());
                        diagString.Append(", ");
                        if (currentOperation == SerializerOperation_T.Deserialize)
                            ar.SetValue(arrayElementBoxObj, idx);
                    }
                    diagString.Append("]");
                    WriteDiagnostic(level, diagString.ToString());
                    return;
                }
                else
                {
                    // This is an array of a complex type; recurse for each element in the array...
                    WriteDiagnostic(level, diagString.ToString());
                    // The following cast operation is required to subscript 'ar'...
                    // Note an array of a primitive type like 'int' cannot be cast to an array of objects.
                    object[] vResObjArray = (object[])ar;
                    for(int i=0; i<len; i++) {
                        object boxObj = vResObjArray[i];
                        navelGaze(name + "[" + i + "]", level + 1, ref boxObj, 0);
                        if (currentOperation == SerializerOperation_T.Deserialize)
                        {
                            // Setting vResObjArray[x] DOES set the original object passed into
                            // this function, as required for deserialization.
                            vResObjArray[i] = boxObj;
                        }
                    }
                    return;
                }
            }
            else if (t.Name == "String")
            {
                // 'String' is actually a class, but normal class handling below blows up...
                diagString.Append("Type="); diagString.Append(t.Name);
                diagString.Append(", value=");
                Munger(ref val, storageSize);
                diagString.Append(val.ToString());
            }
            else if (t.IsClass)
            {
                // Decompose class and recurse over members
                WriteDiagnostic(level, diagString + "Class " + t.Name);
                // Note that custom attributes are associated with the class's fields and properties,
                // NOT the type of the value of the fields/properties, so this must be checked here
                // prior recursion to process the values...
                // GetFields does not get the PROPERTIES of the object, that's very annoying...
                FieldInfo[] fi = val.GetType().GetFields();
                foreach (FieldInfo f in fi)
                {
                    if (f.IsStatic) continue; // ignore class constants
                    // Skip this if the FIELD is marked [HSB_GUI_SerializeSuppress]
                    HSB_GUI_SerializeSuppressAttribute[] GUI_field_suppressSerializationAtt =
                        (HSB_GUI_SerializeSuppressAttribute[])
                        f.GetCustomAttributes(typeof(HSB_GUI_SerializeSuppressAttribute), true);
                    if (GUI_field_suppressSerializationAtt.Length > 0)
                        continue; // this field is marked with "suppress serialization to GUI save are"
                    // Get optional size specifier (required for strings)
                    int nextLevelStorageSize = 0;
                    HSB_GUI_SerializableAttribute[] HSB_GUI_SerializableAtt =
                        (HSB_GUI_SerializableAttribute[])
                        f.GetCustomAttributes(typeof(HSB_GUI_SerializableAttribute), true);
                    if (HSB_GUI_SerializableAtt.Length > 0)
                        nextLevelStorageSize = HSB_GUI_SerializableAtt[0].StorageLength;
                    // box, and gaze into this field...
                    object boxObj = f.GetValue(val);
                    // could replace null with default object constructed here
                    navelGaze(f.Name, level + 1, ref boxObj, nextLevelStorageSize);
                    if (currentOperation == SerializerOperation_T.Deserialize)
                        f.SetValue(val, boxObj);
                }
                // Now iterate over the PROPERTIES
                foreach (PropertyInfo prop in /*typeof(T)*/ val.GetType().GetProperties())
                {
                    // Skip this if the PROPERTY is marked [HSB_GUI_SerializeSuppress]
                    HSB_GUI_SerializeSuppressAttribute[] GUI_prop_suppressSerializationAtt =
                        (HSB_GUI_SerializeSuppressAttribute[])
                        prop.GetCustomAttributes(typeof(HSB_GUI_SerializeSuppressAttribute), true);
                    if (GUI_prop_suppressSerializationAtt.Length > 0)
                        continue; // this property is marked with "suppress serialization to GUI save are"
                    // not relevant; does not occur: if (!type.IsSerializable) continue;
                    // Get optional size specifier (required for strings)
                    int nextLevelStorageSize = 0;
                    HSB_GUI_SerializableAttribute[] HSB_GUI_SerializableAtt =
                        (HSB_GUI_SerializableAttribute[])
                        prop.GetCustomAttributes(typeof(HSB_GUI_SerializableAttribute), true);
                    if (HSB_GUI_SerializableAtt.Length > 0)
                        nextLevelStorageSize = HSB_GUI_SerializableAtt[0].StorageLength;
                    // box, and gaze into this field...
                    object boxObj = prop.GetValue(val, null);
                    // could replace null with default object constructed here
                    navelGaze("Property " + prop.Name, level + 1, ref boxObj, nextLevelStorageSize);
                    if (currentOperation == SerializerOperation_T.Deserialize)
                        prop.SetValue(val, boxObj, null);
                }
                return;
            }
            else if (t.IsEnum)
            {
                Munger(ref val, 0);
                diagString.Append("Enum ("); diagString.Append(t.Name); diagString.Append("), value=");
                diagString.Append(val.ToString()); diagString.Append(", raw value="); diagString.Append((int)val);
            }
            else
            {
                Munger(ref val, 0);
                diagString.Append("Type="); diagString.Append(t.Name);
                diagString.Append(", value="); diagString.Append(val.ToString());
            }
            WriteDiagnostic(level,diagString.ToString());
        }
        public static HSB_Settings_Class DeserializeResult(byte[] datastream)
        {
            Debug.Assert(datastream.Length == 0x0600);
            idx = 0;
            buf = datastream;
            currentOperation = SerializerOperation_T.Deserialize;
            HSB_Settings_Class new_HSB_settings = new HSB_Settings_Class();
            object boxObj = new_HSB_settings;
            navelGaze("DeserializeResult", 0, ref boxObj, 0);
            new_HSB_settings = (HSB_Settings_Class)boxObj;
            Console.WriteLine("==== Deserialization used a total of " + idx.ToString() + " bytes (out of 1536 available) ====");
            return new_HSB_settings;
        }
        public static byte[] SerializeHSBsettings(ref HSB_Settings_Class hsbset)
        {
            idx = 0;
            currentOperation = SerializerOperation_T.Serialize;
            object boxObj = hsbset;
            navelGaze("SerializeHSB", 0, ref boxObj, 0);
            Console.WriteLine("==== Serialization used a total of "+idx.ToString() + " bytes (out of 1536 available) ====");
            return buf;
        }
