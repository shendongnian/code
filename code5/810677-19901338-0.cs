    public static class ParseString
    {
        //Create a static constructor
        static ParseString()
        {
            Parsers = new List<Parser>();
            Parsers.Add(new Parser(ParseInt));
            Parsers.Add(new Parser(ParseDouble));
            Parsers.Add(new Parser(ParseBool));
            Parsers.Add(new Parser(ParseString));
        }
    
        //create a delegate which our parsers will use 
        delegate bool Parser(string source, out object result)
    
        //This is the list of our parsers
        static List<Parser> Parsers;
    
        public static object GenericParse(string source)
        {
            object result;
            foreach(Parser parser in Parsers)
            {
                //return the result if the parser succeded.
                if(parser(source, out result)
                    return result;
            }
    
            //return null if all of the parsers failed (should never happen because the string->string parser can't fail.)
            return null;
        }
    
        private static bool ParseInt(string source, out object result)
        {
            int tmp;
            bool success = int.TryParse(source, out tmp);
            result = tmp;
            return success;
        }
    
        private static bool ParseDouble(string source, out object result)
        {
            double tmp;
            bool success = double.TryParse(source, out tmp);
            result = tmp;
            return success;
        }
    
        private static bool ParseBool(string source, out object result)
        {
            bool tmp;
            bool success = bool.TryParse(source, out tmp);
            result = tmp;
            return success;
        }
    
        private static bool ParseString(string source, out object result)
        {
            result = source;
            return true;
        }
    }
