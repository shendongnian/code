    public class AppModel
    {
        private readonly string _lang;
        public AppModel(string lang)
        {
            _lang = lang;
        }
        public string Home { get { return GetLanguageSpecific("Home"); } }
        public string UserName { get { return GetLanguageSpecific("UserName"); } }
        public string EmailAddress { get { return GetLanguageSpecific("Email Address"); } }
        private string GetLanguageSpecific(string key)
        {
            // fake implementation.
            return string.Format("Requested a string: {0} for language: {1}", key, _lang);
        }
    }
