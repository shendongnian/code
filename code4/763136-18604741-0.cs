	namespace Scraper.Components
	{
		class Scraper
		{
			public Scraper(ISearchEngine engine)
			{
				WebClient client = new WebClient();
				client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; .NET CLR 3.0.04506.30; .NET CLR 3.0.04506.648)");
				engine.Search();
			}
		
		}
		class GoogleSE: ISearchEngine
		{
			public void Search(){
				HtmlDocument doc = new HtmlDocument();
				doc.Load(client.OpenRead("http:\\google.com"));
				HtmlNode rootNode = doc.DocumentNode;
				HtmlNodeCollection adNodes = rootNode.SelectNodes("//a[@class='ad-title']");
				foreach(HtmlNode adNode in adNodes) {
					Debug.WriteLine(
						adNode.Attributes["href"].Value
					);
				}
			}
		}
		
		Interface ISearchEngine{
			void Search();
		}
	}
