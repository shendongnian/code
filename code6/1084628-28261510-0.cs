    using System.Diagnostics;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
    	// Scrape links from wikipedia.org
    
    	// 1.
    	// URL: http://en.wikipedia.org/wiki/Main_Page
    	WebClient w = new WebClient();
    	string s = w.DownloadString("http://en.wikipedia.org/wiki/Main_Page");
    
    	// 2.
    	foreach (LinkItem i in LinkFinder.Find(s))
    	{
    	    Debug.WriteLine(i);
    	}
        }
    }
