    var message = errorObject
        .GetProperty("message")
        .ToString();
    var source = errorObject
        .GetProperty("source")
        .ToString();
    var line = (int)errorObject
        .GetProperty("line")
        .ToDouble();
    var column = (int)errorObject
        .GetProperty("column")
        .ToDouble();
    var length = (int)errorObject
        .GetProperty("length")
        .ToDouble();
    throw new JavaScriptParseException(error, message, source, line, column, length);
