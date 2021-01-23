    public delegate void JobClassNavigationEvent(string url);
    public static class JobClass
    {
        public static event JobClassNavigationEvent OnNavigationChanged;
        private static BackgroundWorker worker;
        public static void mainAsync()
        {
            worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                main();
            };
            worker.RunWorkerAsync();
        }
        private static void main()
        {
            gotoGoogle();
        }
        private static void gotoGoogle()
        {
            if (OnNavigationChanged != null)
                OnNavigationChanged.Invoke("google.com");
        }
        private static void gotoYoutube()
        {
            if (OnNavigationChanged != null)
                OnNavigationChanged.Invoke("youtube.com");
        }
    }
