    public class NoBlankStreamReader : StreamReader
    {
        public NoBlankStreamReader(FileStream fs) : base(fs) { }
    
    
        private bool IsBlank(string inString)
        {
            if (!string.IsNullOrEmpty(inString)) inString = inString.Trim();
            return string.IsNullOrEmpty(inString);
        }
    
    
        public override string ReadLine()
        {
            string result= base.ReadLine();
            while (result!=null && IsBlank(result))
                result = base.ReadLine();
            return result;
        }
    }
