    var players = from p in doc.DocumentNode.SelectNodes("//li")
                  let name = p.SelectSingleNode("span[@class='name']/a")
                  let country = p.SelectSingleNode("span[@class='country']")
                  select new
                  {
                      Name = (name == null) ? null : 
                             HttpUtility.HtmlDecode(name.InnerText.Trim()),
                      Country = (country == null) ? null :
                             HttpUtility.HtmlDecode(country.InnerText.Trim())
                  };
