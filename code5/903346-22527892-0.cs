        public static class StringExtensions
        {
            public static string ecleaner(this string str
            {
                return Regex.Replace(str, "[éèê]+", "e", RegexOptions.Compiled);
            }
		
            public static string acleaner(this string str)
            {
               return Regex.Replace(str, "[áàâ]+", "a", RegexOptions.Compiled);
            }
        }
	
        //...
	
        var result = ""Téèááést".ecleaner().acleaner();
