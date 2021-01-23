    return swimlaneAttributeTable.Select(s => new
    {
        ID = s.Id,
        DataType = s.AttributeDataType,
        IsCriticalField = s.IsCriticalField,
    });
