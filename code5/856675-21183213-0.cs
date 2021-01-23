    public override Array GetEnumValues()
    {
        ulong[] values = Enum.InternalGetValues(this);
        Array array = Array.UnsafeCreateInstance(this, values.Length);
        for (int i = 0; i < values.Length; i++)
        {
            object obj2 = Enum.ToObject(this, values[i]);
            array.SetValue(obj2, i);
        }
        return array;
    }
