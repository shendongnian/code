    class MyClass
    {
        static Dictionary<char, string> _map = new Dictionary<char, string>();
    
        static MyClass()
        {
            _map.Add('a', "Alpha");
            _map.Add('b', "Beta");
            // etc
        }
    
        static string WordMap(string data)
        {
            var output = new StringBuilder();
            foreach (char c in data)
            {
                if (_map.ContainsKey(c))
                {
                    output.Append(_map[c]);
                    output.Append(' ');
                }
            }
            return output.ToString();
        }
    }
