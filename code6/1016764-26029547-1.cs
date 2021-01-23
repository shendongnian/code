    public IEnumerable<string> Validate(ClassToValidate obj)
    {
        var subObjectMessages = ValidateSubObject(obj.OtherObjectToValidate);
        if (string.IsNullOrEmpty(obj.Name))
        {
            return new[] { "empty name" }.Concat(subObjectMessages);
        }
        return subObjectMessages;
    }
