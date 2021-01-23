     static class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"D:\1.txt"))
            { 
                String s = null;
                while ((s = sr.ReadUntil('-')) != null)
                {
                    if (s.StartsWith("P"))
                    { 
                        
                        //crate object
                    }
                    if (s.StartsWith("B"))
                    {
                        //..
                    }
                }
            }
        }
        public static String ReadUntil(this StreamReader reader, char delimeter)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            while ((c = (char)reader.Read()) != 0)
            {
                if (c == delimeter)
                    return sb.ToString();
                else
                    sb.Append(c);
            }
            return sb.Length == 0 ? null:sb.ToString();
        }
    }
