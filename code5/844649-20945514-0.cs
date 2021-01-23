    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using LinqToVisualTree;
    using Microsoft.Phone.Controls;
    using System.Collections.Generic;
    using System.Windows.Media;
    namespace InvertBrowser
    {
        class WebBrowserHelper
        {
            private WebBrowser _browser;
            public bool ScrollDisabled { get; set; }
            public WebBrowserHelper(WebBrowser browser)
            {
                _browser = browser;
                browser.Loaded += new RoutedEventHandler(browser_Loaded);
            }
            private void browser_Loaded(object sender, RoutedEventArgs e)
            {
                IEnumerable<DependencyObject> borders = _browser.Descendants<Border>();
                foreach (var o in borders)
                {
                    var ding = o as Border;
                    ding.Background = new SolidColorBrush(Colors.Black);
                }
            }
        }
    }
