        public static string[] FileNamesExcluding(string path, string pattern, string textToExclude)
        {
            // Put all txt files in root directory into array.
            string[] allFilesMatchingPattern = Directory.GetFiles(path, pattern); // <-- Case-insensitive
            return allFilesMatchingPattern.SkipWhile(a => a.Contains(textToExclude)).ToArray();
        }
