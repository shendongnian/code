    abstract class Unicode
    {
        public static string CountCharacters(string text)
        {
            return GetConcreteClass().CountCharactersCore(text);
        }
    
        protected virtual string CountCharactersCore(string text)
        {
            // Default implementation, overridden in derived classes if needed
            return StringInfo.GetTextElementEnumerator(text).Cast<string>()
                .Distinct().Count();
        }
    
        private Dictionary<string, Unicode> _implementations;
    
        private Unicode GetConcreteClass()
        {
            string cultureName = Thread.Current.CurrentCulture.Name;
            
            // Check if concrete class has been loaded and put in dictionary
            ...
         
            return _implementations[cultureName];
        }
    }
