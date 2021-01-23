    protected void LoadXML()
        {
            var wc = new WebClient();
            using (var sourceStream = wc.OpenRead("http://www.cpalead.com/dashboard/reports/campaign_rss.php?id=187000"))
            {
                using (var reader = new StreamReader(sourceStream))
                {
                    XDocument ourBlog = XDocument.Load(reader);
                    XNamespace NameSpace = "http://www.cpalead.com/feeds/campinfo.php";
                    var XMLItem = from item in ourBlog.Descendants("item")
                                  select new
                                  {
                                      title = item.Element("title").Value,
                                      link = item.Element("link").Value,
                                      guid = item.Element("guid").Value,
                                      description = XmlConvert.VerifyXmlChars(item.Element("description").Value),
                                      amount = item.Element(NameSpace + "amount").Value,
                                      campid = item.Element(NameSpace + "campid").Value,
                                      country = item.Element(NameSpace + "country").Value,
                                      type = item.Element(NameSpace + "type").Value,
                                      epc = item.Element(NameSpace + "epc").Value,
                                      ratio = item.Element(NameSpace + "ratio").Value
                                  };
                    foreach (var item in XMLItem)
                    {
                        offers.InnerHtml += item.title + " : " + item.description + " : " + item.amount + "<br />"; 
                    }
                }
            }
        }
