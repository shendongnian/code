    foreach (var validationResult in validationResults)
    {
        if (validationResult == null)
        {
            continue;
        }
        // let's treat null or empty .MemberNames the same way as one undefined (null) memberName
        var memberNames = validationResult.MemberNames == null || !validationResult.MemberNames.Any()
                                ? new string[] { null }
                                : validationResult.MemberNames;
    
        foreach (var memberName in memberNames)
        {
            yield return new DbValidationError(memberName ?? propertyName, validationResult.ErrorMessage);
        }
    }
