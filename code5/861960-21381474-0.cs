    public partial class BrowserWindow : Window
            {
                public BrowserWindow(string url)
                {
                    InitializeComponent();
                    WebView.ScriptErrorsSuppressed = true;
                    WebView.AllowNavigation = true;
                    WebView.Navigate(new Uri(url));
                    WebView.DocumentCompleted += LoadCompleteEventHandler;
                }
        
                private void LoadCompleteEventHandler(object sender, WebBrowserDocumentCompletedEventArgs navigationEventArgs)
                {
                    HtmlElementCollection elements = this.WebView.Document.GetElementsByTagName("input");
                    foreach (HtmlElement input in elements)
                    {
                        if (input.GetAttribute("type").ToLower() == "text")
                        {
                            input.GotFocus += (o, args) => VirtualKeyBoardHelper.AttachTabTip();
                            input.LostFocus += (o, args) => VirtualKeyBoardHelper.RemoveTabTip();
                        }
                    }
                }
            }
