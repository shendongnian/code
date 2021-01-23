    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetUrls();
            GetUrls2();
        }
        private void GetUrls()
        {
            var response = Task.Run(() => Browser.login("http://yahoo.com"));
            response.Wait();
            Debug.WriteLine("Complete GetUrls()");
        }
        private void GetUrls2()
        {
            var browseTask = Browser.login("http://yahoo.com");
            browseTask.ContinueWith((r) => Debug.WriteLine("Complete GetUrls2()"));
        }
    }
    static public class Browser
    {
        static public async Task<HttpResponseMessage> login(string site)
        {
            var browser = new HttpClient();
            return await browser.GetAsync(site);
        }
    }
