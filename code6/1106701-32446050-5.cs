    private IDictionary<string, string> GetCookieData()
    {
        var cookieDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (!this.Headers.Cookie.Any())
        {
            return cookieDictionary;
        }
        var values = this.Headers["cookie"].First().TrimEnd(';').Split(';');
        foreach (var parts in values.Select(c => c.Split(new[] { '=' }, 2)))
        {
            var cookieName = parts[0].Trim();
            string cookieValue;
            if (parts.Length == 1)
            {
                //Cookie attribute
                cookieValue = string.Empty;
            }
            else
            {
                cookieValue = parts[1];
            }
            cookieDictionary[cookieName] = cookieValue;
        }
        return cookieDictionary;
    }
