    public static bool PropertiesEqual<T>(this T self, T other, params string[] skip)
    {
        if (self == null) return other == null;
        if (self.Equals(other)) return true;
        var properties = from p in typeof(T).GetProperties()
                            where !skip.Contains(p.Name)
                            && !p.PropertyType.IsByRef // take only structs and string
                            select p;
        foreach (var p in properties)
        {
            var selfValue = p.GetValue(self);
            var otherValue = p.GetValue(other);
            if (!object.Equals(selfValue, otherValue))
                return false;
        }
        return true;
    }
