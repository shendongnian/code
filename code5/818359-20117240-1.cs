    var qatype = typeof(QATypes);
    var names = qatype.GetEnumNames();
    var values = qatype.GetEnumValues().Cast<int>().ToList();
    var nameValues = names.Select(n =>
            qatype.GetMember(n)[0]
                .CustomAttributes.First()
                .NamedArguments[0].TypedValue
                .Value)
        .ToList();
    var valuesList = names.Select((n, index) =>
            new { key = n, value = values[index] })
        .ToList();
    var nameValuesList = names.Select((n, index) =>
            new { key = n, value = nameValues[index] })
        .ToList();
