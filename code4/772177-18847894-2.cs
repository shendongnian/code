    public static bool IsDefaultValue(object @object) {
        if (null == @object)
            return true;
        else if (@object.GetType().IsValueType) {
            var isDefault = Activator.CreateInstance(@object.GetType()).Equals(@object);
            return isDefault;
        } else
            return false;
    }
