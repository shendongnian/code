    public class Driver
    {
        public static IWebDriver Instance { get; private set; }
        public static void Initialise()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
	}
