    using (var client = new WebClient())
    {
          string content = client.DownloadString("http://weather.yahooapis.com/forecastrss?w=2357473");
          var rootElement = XDocument.Parse(content).Root;
          if (rootElement != null)
          {
               var lastBuild = (string)rootElement.Element("channel")
                                      .Element("lastBuildDate");
               if (lastBuild != null)
               {
                     // display value in the label
               }
           }
    }
