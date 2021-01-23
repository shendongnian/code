    abstract class Unicode
    {
        public static string ToUpper(string text)
        {
            return GetConcreteClass().ToUpperCore(text);
        }
    
        protected virtual string ToUpperCore(string text)
        {
            // Default implementation, overridden in derived classes if needed
            return text.ToUpper();
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
