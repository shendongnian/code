    byte[] bytes = new byte[8];
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(bytes);
    }
    string key = string.Join("", bytes.Select(b => b.ToString("X2")));
