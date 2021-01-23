        public static MultiLanguageManager {
            private static Dictionary<string, Dictionary<string, string>> ContentCache;
            ...
            public static GetResource(string key, string language) {
                return (ContentCache[language])[key];
            }
        }
