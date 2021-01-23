    public class App 
    {
        public static IUserPreferences UserPreferences { get; private set; }
    
        public static Init(IUserPreferences userPreferencesImpl) 
        {
            App.UserPreferences = userPreferencesImpl;
        }
    
        (...)
    }
