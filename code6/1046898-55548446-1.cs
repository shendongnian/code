    // If target contains desiredField, then returns it as a TypedReference,
    // otherwise, returns the reference to the last field
    private static unsafe void MakeTypedReference(TypedReference* result, object target, FieldInfo desiredField = null)
    {
        var flds = new List<IntPtr>();
        Type lastType = target.GetType();
        foreach (FieldInfo f in target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            flds.Add(f.FieldHandle.Value);
            lastType = f.FieldType;
            if (f == desiredField)
                break;
        }
        InternalMakeTypedReference.DynamicInvoke((IntPtr)result, target, flds.ToArray(), lastType);
    }
