    internal sealed class TranslateTokenViewEngineMatcher :
        ISuperSimpleViewEngineMatcher
    {
        /// <summary>
        ///   Compiled Regex for translation substitutions.
        /// </summary>
        private static readonly Regex TranslationSubstitutionsRegEx;
        static TranslateTokenViewEngineMatcher()
        {
            // This regex will match strings like:
            // @Translate.Hello_World
            // @Translate.FooBarBaz;
            TranslationSubstitutionsRegEx =
                new Regex(
                    @"@Translate\.(?<TranslationKey>[a-zA-Z0-9-_]+);?",
                    RegexOptions.Compiled);
        }
        public string Invoke(string content, dynamic model, IViewEngineHost host)
        {
            return TranslationSubstitutionsRegEx.Replace(
                content,
                m =>
                {
                    // A match was found!
                    string translationResult;
                    // Get the translation 'key'.
                    var translationKey = m.Groups["TranslationKey"].Value;
                    // Load the appropriate translation.  This could farm off to
                    // a ResourceManager for example.  The below implementation
                    // obviously isn't very useful and is just illustrative. :)
                    if (translationKey == "Hello_World")
                    {
                        translationResult = "Hello World!";
                    }
                    else 
                    {
                        // We didn't find any translation key matches so we will
                        // use the key itself.
                        translationResult = translationKey;
                    }
                    
                    return translationResult;
                });
        }
    }
