    //Code 3
    public class Settings
    {
        private static CultureInfo culture = CultureInfo.InvariantCulture;
        public static CultureInfo Culture
        {
            get { return culture; }
            set { culture = value; }
        }
        public static void SetCulture(string name)
        {
            culture = new CultureInfo(name);
        }
    }
<!---->
    //code 2
    public class ExceptionHandler
    {
        static ResourceManager rm = new ResourceManager("Languages.Language", System.Reflection.Assembly.LoadFrom("Languages.dll"));
    
        public static void test(EventArgs e)
        {
            ParseException(null, new ExceptionHandlerEventArgs() { ExceptionMessage = rm.GetString("exDefault", Settings.Culture) });
        }
    }
