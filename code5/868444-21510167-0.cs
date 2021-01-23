    object value;
    if (pair.Value == null) {
        value = null;
    } else {
        value = pair.Value.GetType().IsStruct ? Convert.ChangeType(pair.Value, propType) : pair.Value;
    }
    ...
