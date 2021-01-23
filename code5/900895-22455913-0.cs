    var code = 0;
    if (!int.TryParse(Self.textField.text, out code))
    {
        // numeric parsing failed, handle the error condition
    }
    // if parsing succeeded, here "code" has the numeric integer value
