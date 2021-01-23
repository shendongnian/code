    public class App 
    {
        public static IUserPreferences UserPreferences { get; private set; }
    
        public static void Init(IUserPreferences userPreferencesImpl) 
        {
            App.UserPreferences = userPreferencesImpl;
        }
    
        (...)
    }
