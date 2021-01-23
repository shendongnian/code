    using System;
    using HtmlAgilityPack;
    namespace com.mp3skull.scrapper
    {
        class Program
        {
            private static void Main(string[] args)
            {
                var p = new Program();
                HtmlNodeCollection songs = p.GetSongNodesFromPage("http://mp3skull.com/mp3/move_that_dope.html");
                p.WriteSongsToConsole(songs);
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
            private readonly HtmlWeb web = new HtmlWeb();
            private HtmlNodeCollection GetSongNodesFromPage(string pageUri)
            {
                HtmlDocument document = web.Load(pageUri);
                HtmlNode documentNode = document.DocumentNode;
                return documentNode.SelectNodes("//div[@id='right_song']");
            }
            private void WriteSongsToConsole(HtmlNodeCollection songs)
            {
                foreach (HtmlNode s in songs)
                {
                    HtmlNode titleNode = s.SelectSingleNode(".//b"); // Title is bold
                    string title = titleNode.InnerText;
                    HtmlNode downloadLinkNode = s.SelectSingleNode(".//a[@style='color:green;']");
                    string downloadLink = downloadLinkNode.Attributes["href"].Value;
                    Console.WriteLine("Title: {0}\t", title);
                    Console.WriteLine("Download link: {0}\t", downloadLink);
                    Console.WriteLine();
                }
            }
        }
    }
