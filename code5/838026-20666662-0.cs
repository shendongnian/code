    var p = new Parser();
    byte[][] data = p.Parse("{ 0, 0, 5 },{  1, 255, 1 }");
    class Parser
    {
        char c;
        int i;
        string data;
    
        private bool next()
        {
            if (i == data.Length) { c = (char)0; return false; }
            else { c = data[i++]; return true; }
        }
    
        public byte[][] Parse(string data)
        {
            this.data = data;
            if (data.Length == 0) return null;
            i = 0;
            List<List<byte>> result = new List<List<byte>>();
            List<byte> currentList = new List<byte>();
            while (next())
            {
                switch (c)
                {
                    case '{': currentList = new List<byte>(); break;
                    case '}': result.Add(currentList);        break;
                    default : ParseByte(currentList);         break;
                }
            }
            return result.Select(l => l.ToArray()).ToArray();
        }
    
        private void ParseByte(List<byte> currentList)
        {
            if (!char.IsDigit(c)) return;
            byte currentByte = 0;
            while (char.IsDigit(c))
            {
                currentByte *= 10;
                currentByte += (byte)(c - '0');
                next();
            }
            currentList.Add(currentByte);
        }
    }
