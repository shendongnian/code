    Param = Regex.Replace(Param, @"\[(.+?)\]", m =>
    {
        string paramName = m.Groups[1].Value;
        string paramValue = arrayval.Select(s => s.Split(new[] { ':' }, 2))
                                    .Where(p => p.Length == 2)
                                    .Where(p => p[0] == paramName)
                                    .Select(p => p[1])
                                    .FirstOrDefault();
        return paramValue ?? m.Value;
    });
