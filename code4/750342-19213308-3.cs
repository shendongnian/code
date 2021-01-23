        
    public class customInter : IResourceInterceptor
    {
        public ResourceResponse OnRequest(ResourceRequest request)
        {
            // Put your code here
            return null;
        }
        public bool OnFilterNavigation(NavigationRequest request)
        {
            return false;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WebCoreOnStarted(object sender, 
                                      CoreStartEventArgs coreStartEventArgs)
        {
            var interc = new customInter();
            WebCore.ResourceInterceptor = interc;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var interc = new customInter();
            WebCore.ResourceInterceptor = interc;
            // Replace "webControl1" and Uri with your information
            this.webControl1.Source = new Uri("http://example-site.com");
        }
    }
