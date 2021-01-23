    public class IniFile
    {
        private readonly string path;
        public IniFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            this.path = path;
        }
        public string Path { get { return path; } }
        
        public bool WriteSection(string section, string key, IEnumerable<string> lines)
        {
            if (String.IsNullOrWhiteSpace(section))
                return false;
            if (String.IsNullOrWhiteSpace(key))
                return false;
            return WritePrivateProfileSection(section, ToSectionValueString(key, lines));
        }
        
        private string ToSectionValueString(String key, IEnumerable<string> lines)
        {
            if (lines == null)
                return null;
            if (lines.Count() == 1)
                return key + "=" + lines.Single();
            return String.Join("\0",
                lines.Select((line, i) => (key + "." + i) + "=" + line)
            );
        }
        
        public bool WriteSection(string section, IEnumerable<KeyValuePair<string, string>> values)
        {
            if (String.IsNullOrWhiteSpace(section))
                return false;
            return WritePrivateProfileSection(section, ToSectionValueString(values));
        }
        
        private string ToSectionValueString(IEnumerable<KeyValuePair<string, string>> values)
        {
            if (values == null)
                return null;
            return String.Join("\0", values.Select(kvp => kvp.Key + "=" + kvp.Value));
        }
        
        public List<KeyValuePair<string, string>> ReadSection(string section)
        {
            var buff = new byte[SectionSizeMax];
            var count = GetPrivateProfileSection(section, buff);
            return ToSectionValueList(buff, (int)count);
        }
        
        private List<KeyValuePair<string, string>> ToSectionValueList(byte[] buff, int count)
        {
            return EnumerateValues(buff, count)
                .Select(v => v.Split('='))
                .Where(s => s.Length == 2)
                .Select(s => new KeyValuePair<string, string>(s[0], s[1]))
                .ToList();
        }
        
        private IEnumerable<string> EnumerateValues(byte[] buff, int count)
        {
            var value = new StringBuilder();
            foreach (var b in buff)
            {
                var c = (char)b;
                if (c != '\0')
                {
                    value.Append(c);
                }
                else
                {
                    yield return value.ToString();
                    value.Clear();
                }
            }
        }
        
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);
        private bool WritePrivateProfileSection(string lpAppName, string lpString)
        {
            return WritePrivateProfileSection(lpAppName, lpString, path);
        }
        
        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, uint nSize, string lpFileName);
        private uint GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString)
        {
            return GetPrivateProfileSection(lpAppName, lpReturnedString, (uint)lpReturnedString.Length, path);
        }
        const uint SectionSizeMax = 0x7FFF;
    }
