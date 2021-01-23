    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                return;
            }
    
            var pageUrl = args.First();
            var options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager
            };
    
            using (var htmlLoader = new WebSiteHtmlLoader(new InternetExplorerDriver(options)))
            {
                var html = htmlLoader.GetRenderedHtml(new Uri(pageUrl, UriKind.Absolute));
                File.WriteAllText(@"C:\htmlloadertext.html", html);
            }
        }
    }
