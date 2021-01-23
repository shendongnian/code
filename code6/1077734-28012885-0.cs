            XDocument doc;
            using (Stream input = System.IO.File.OpenRead(@"D:\Test.xml"))
            {
                doc = XDocument.Load(input);
                foreach (var hostedService in doc.Root.Elements("HostedService")) // loop through all events
                {
                    if (hostedService.Element("ServiceName") != null)
                    {
                        var service = hostedService.Element("ServiceName").Value;
                    }
                    if (hostedService.Element("Url") != null)
                    {
                        var url = hostedService.Element("Url").Value;
                    }
                }
            }
