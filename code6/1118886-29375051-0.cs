    var declaringType = new GenericInstanceType(definition.DeclaringType);
    foreach (var parameter in definition.DeclaringType.GenericParameters)
    {
         declaringType.GenericArguments.Add(parameter);
    }
    return new FieldReference(definition.Name, definition.FieldType, declaringType);
