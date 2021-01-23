    public class JobClass
    {
        public static event JobClsasNavigationEvent OnNavigationChanged;
        public static void mainAsync()
        {
            Thread t = new Thread(main);
            t.Start();
        }
    private static void main()
    {
        gotoGoogle();
    }
    private static void gotoGoogle()
    {
        if(OnNavigationChanged!=null)
            OnNavigationChanged("google.com");
    }
    private static void gotoYoutube()
    {
        if(OnNavigationChanged!=null)
            OnNavigationChanged("youtube.com");
    }
