    var doc = new HtmlDocument();
    
    string xml = @"<root>
                      <div id=""main"">
                        <div class=""content"">
                            <ul>
                                <li>
                                    <div>Test</div>
                                </li>
                            <ul>
                        </div>
                      </div>
                    </root>";
    
    var bytes = System.Text.Encoding.UTF8.GetBytes(xml);
    var memStream = new MemoryStream(bytes);
    
    doc.Load(memStream);
    
    var innerText =
    doc.DocumentNode.Descendants("div").Where(x => x.GetAttributeValue("id", null) == "main").First()
    .Descendants("div").Where(x => x.GetAttributeValue("class", null) == "content").First()
    .Elements("ul").First()
    .Elements("li").First()
    .Elements("div").First().InnerText;
