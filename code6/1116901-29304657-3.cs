    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using HtmlAgilityPack;
    namespace ConsoleApplication276
    {
        class Program
        {
            static void Main(string[] args)
            {
                var t = new Thread(ParseSomeHtmlThatRenderedJavascript);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                Console.ReadLine();
            }
    
            private static void ParseSomeHtmlThatRenderedJavascript()
            {
                var browser = new System.Windows.Forms.WebBrowser() { ScriptErrorsSuppressed = true };
    
                string link = "yourLinkHere";
    
                //This will be called when the web page loads, it better be a class member since this is just a simple demonstration
                WebBrowserDocumentCompletedEventHandler onDocumentCompleted = new WebBrowserDocumentCompletedEventHandler((s, evt) =>
                {
                    //Do your HtmlParsingHere
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(browser.DocumentText);
                    var someNode = doc.DocumentNode.SelectNodes("yourxpathHere");
                });
    
                //subscribe to the DocumentCompleted event using our above handler before navigating
                browser.DocumentCompleted += onDocumentCompleted;
    
                browser.Navigate(link);
            }
        }
    }
