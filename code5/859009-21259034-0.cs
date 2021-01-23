    var missing = idCheck.Select((b, idx) => new { IsPresent = b, Idx = idx })
        .Where(p => !p.IsPresent)
        .Select(p => p.Idx);
    
    string message = string.Format("Missing ids from File 1 are {0}", string.Join("," missing));
    ResetBuilder.Apppend(message);
