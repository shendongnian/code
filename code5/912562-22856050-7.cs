    DateTimeFormatInfo dti = CultureInfo.InvariantCulture.DateTimeFormat;
    dynamic hashes = dti.GetType().GetMethod("CreateTokenHashTable", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(dti, null);
    var tokens = Enumerable.Repeat(new { str = "", type = "", value = "" }, 0).ToList();
    foreach (dynamic hash in hashes)
        if (hash != null)
        {
            Type hashType = hash.GetType();
            tokens.Add(new { str = (string)hashType.GetField("tokenString", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(hash).ToString(),
                             type = (string)hashType.GetField("tokenType", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(hash).ToString(),
                             value = (string)hashType.GetField("tokenValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(hash).ToString() });
        }
    foreach (var token in tokens.Distinct().OrderBy(t => t.type).ThenBy(t => t.value))
        Console.WriteLine("{0,10} {1} {2}", token.str, token.type, token.value);
