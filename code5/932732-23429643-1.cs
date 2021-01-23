    List<string> topicList = new List<string>; 
    List<string> authorList = new List<string>; 
    List<string> lastPostList = new List<string>; 
    foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//td[@class='topic starter']"))
                {
                     string topic;
                     topic = node.InnerText;
                     topicList.Add(topic);
                }
    foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//td[@class='author']"))
                {
                     string author;
                     author = node.InnerText;
                     authorList.Add(author);
                }
    foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//td[@class='lastpost']"))
                    {
                         string lastpost;
                         lastpost = node.InnerText;
                         lastPostList.Add(lastpost); // This will take also the author that posted last post (e.g. Antony 24/10/09).
                    }
