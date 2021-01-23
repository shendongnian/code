    public static class Extensions {
        static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        //#1
        public static bool IsLowerCase( this string word ){
            return word.All( c => c >= 'a' && c <= 'z' );
        }
        //#2
        public static bool ContainsVowels( this string word ) {
            int count = word.Count( c => vowels.Contains( c ) );
            return ( count >= 1 && word.Length < 5 ) || ( count > 1 && word.Length >= 5 );
        }
        //#3 
        public static bool AreVowelsOrdered( this string word ) {
            char? lastVowel = null;
            foreach ( char c in word ) {
                if ( vowels.Contains( c ) ) {
                    if ( lastVowel == null || c > lastVowel )
                        lastVowel = c;
                    else if ( c < lastVowel )
                        return false;                 
                }
            }
            return true;
        }
    }
