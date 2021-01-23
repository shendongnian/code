    base64String = base64String.Replace("-", "+").Replace("_", "/");
    var base64 = Encoding.ASCII.GetBytes(base64String);
    var padding = base64.Length * 3 % 4;//(base64.Length*6 % 8)/2
    if (padding != 0)
    {
        base64String = base64String.PadRight(base64String.Length + padding, '=');
    }
    return Convert.FromBase64String(base64String);
