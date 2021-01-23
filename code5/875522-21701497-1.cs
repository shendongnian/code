    HtmlDocument doc = new HtmlDocument();            
    doc.Load("index.html");
    var users = from r in doc.DocumentNode.SelectNodes("//table/tr")
                let cells = r.SelectNodes("td")
                select new User
                {
                    Id = Int32.Parse(cells[0].InnerText),
                    Name = cells[1].InnerText
                };
    // NOTE: you can check cells count before accessing them by index
