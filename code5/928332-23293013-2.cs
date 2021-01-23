    using HtmlAgilityPack;
    using System;
    using System.Text;
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
                return documentNode.SelectNodes("//div[@id='song_html']");
            }
            private void WriteSongsToConsole(HtmlNodeCollection songs)
            {
                foreach (HtmlNode s in songs)
                {
                    HtmlNode titleNode = s.SelectSingleNode(".//b"); // Title is bold
                    string title = titleNode.InnerText;
                    HtmlNode downloadLinkNode = s.SelectSingleNode(".//a[@style='color:green;']");  // Download links is green
                    string downloadLink = downloadLinkNode.Attributes["href"].Value;
                    HtmlNode songInfoNode = s.SelectSingleNode("./div[@class='left']");
                    string songInfo = GetSongInfoLine(songInfoNode);
                    Console.WriteLine("Title: {0}\t", title);
                    Console.WriteLine("Information: {0}\t", songInfo);
                    Console.WriteLine("Download link: {0}\t", downloadLink);
                    Console.WriteLine();
                }
            }
            private string GetSongInfoLine(HtmlNode songInfoNode)
            {
                var textNodes = songInfoNode.Descendants("#text");
                var infoBuilder = new StringBuilder();
            
                foreach (var node in textNodes)
                {
                    if (infoBuilder.Length > 0)
                    {
                        infoBuilder.Append(", ");
                    }
                    infoBuilder.Append(node.InnerText.Trim());
                }
                return infoBuilder.ToString();
            }
        }
    }
