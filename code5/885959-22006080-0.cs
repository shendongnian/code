    class MagicEncoder
    {
        private Dictionary<string, string> encodedStrings = new private Dictionary<string, string>();
    
        public string Encode(string input)
        {
            var code = Guid.NewGuid().ToString("N");
            this.encodedStrings[code] = input;
            return code;
        }
    
        public string Decode(string code)
        {
            string output;
            if (this.encodedString.TryGetValue(code, out output))
            {
                 return output;
            }
    
            throw new ArgumengException("Unknown encoding.");
        }
    }
