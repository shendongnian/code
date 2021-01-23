    // Example of GUID to checking:
    // {6F9619FF-8B86-D011-B42D-00CF4FC964FF}
    var result = new StringBuilder();
    result.Append(source.Substring(1, 8));
    result.Append(source.Substring(10, 4));
    result.Append(source.Substring(15, 4));
    result.Append(source.Substring(20, 4));
    result.Append(source.Substring(25, 12));
    return result.ToString();
