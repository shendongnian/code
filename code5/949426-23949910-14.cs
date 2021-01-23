    public class Setting
    {
        public Setting(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }
        public string Name { get; private set; }
        public IDictionary<string,string> Parameters { get; set; }
    }
    public class SettingsParser
    {
        public Setting ExtractLine(string line)
        {
            var pos = line.IndexOfAny(new[] {'=', ':'});
            if (pos == -1 || line[pos] == ':')
                throw new FormatException("Expected an equals sign and that it's positioned before the first colon");
            var setting = new Setting(line.Substring(0, pos));
            setting.Parameters= ExtractParameters(line.Substring(pos + 1));
            
            return setting;
        }
        private IDictionary<string, string> ExtractParameters(string paramString)
        {
            var keyValues = paramString.Split(' ');
            var items = new Dictionary<string, string>();
            foreach (var keyValue in keyValues)
            {
                var pos = keyValue.IndexOf(':');
                if (pos == -1)
                    throw new FormatException("Expected a colon for property " + keyValue);
                items.Add(keyValue.Substring(0, pos), keyValue.Substring(pos + 1));
            }
            return items;
        }
    }
