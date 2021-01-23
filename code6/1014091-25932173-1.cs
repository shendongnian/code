    public string FormatType(Type t) {
        if (t.IsGenericType) {
            return string.Format(
                "{0}.{1}<{2}>",
                t.Namespace,
                t.Name.Substring(0, t.Name.IndexOf('`')),
                string.Join(", ", t.GetGenericArguments().Select(FormatType))
            );
        }
        return t.ToString();
    }
