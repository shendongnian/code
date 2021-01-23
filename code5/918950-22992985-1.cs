    public static bool LegalString(string s) {
        if (!s.All(Char.IsLetterOrDigit)) {
            Console.WriteLine( "'{0}'", s.First(c => !Char.IsLetterOrDigit(c)));
            return false;
        }
        return true;        
    }
