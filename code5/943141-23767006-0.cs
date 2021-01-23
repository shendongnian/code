    public partial class App : Application
    {
        private JrTaskbarIcon taskbarIcon;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ResourceDictionary resources = (ResourceDictionary) FindResource("TaskbarIcon");
            taskbarIcon = (JrTaskbarIcon) resources.MergedDictionaries[0]
                                                   .Values
                                                   .OfType<object>()
                                                   .FirstOrDefault();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
