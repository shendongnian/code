        static public void setConfigValue(string key, object value)
        {
            var settings = File.ReadAllLines("config.cfg")
                .Select((p) =>
                    {
                        string[] temp = p.Split('=');
                        return new { Key = temp[0], Value = temp[1] };
                    })
                .ToDictionary((p) => p.Key, (p) => p.Value);
            settings[key] = value.ToString();
            var newContents = settings
                .Select((p) => string.Concat(p.Key, '=', p.Value))
                .OrderBy((p) => p, StringComparer.OrdinalIgnoreCase)
                .ToList();
            File.WriteAllLines("config.cfg", newContents);
        }
