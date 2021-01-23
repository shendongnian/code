    var str = "Welcome to the world";
    var parts = System.Text.RegularExpressions.Regex.Split(str, " ");
    Array.Reverse(parts);
    var sb = new StringBuilder();
    foreach (var part in parts)
    {
        sb.Append(part);
        sb.Append(' ');
    }
    if (sb.Length > 0)
    {
        sb.Length--;
    }
    var str2 = sb.ToString();
