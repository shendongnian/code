     var url = "http://www.eurexchange.com/action/exchange-en/4744-19066/19068/quotesSingleViewOption.do?callPut=Put&maturityDate=201411";
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var pricesAndQuotesDataTable =
                (from elem in
                    document.DocumentNode.Descendants()
                        .Where(
                            d =>
                                d.Attributes["class"] != null && d.Attributes["class"].Value == "toggleTitle" &&
                                d.ChildNodes.Any(h => h.InnerText != null && h.InnerText == "Prices/Quotes"))
                    select
                        elem.Descendants()
                            .FirstOrDefault(
                                d => d.Attributes["class"] != null && d.Attributes["class"].Value == "dataTable")).FirstOrDefault();
            if (pricesAndQuotesDataTable != null)
            {
                var dataRows = from elem in pricesAndQuotesDataTable.Descendants()
                    where elem.Name == "tr" && elem.ParentNode.Name == "tbody"
                    select elem;
                var dataPoints = new List<object>();
                foreach (var row in dataRows)
                {
                    var dataColumns = (from col in row.ChildNodes.Where(n => n.Name == "td")
                        select col).ToList();
                    dataPoints.Add(
                        new
                        {
                            StrikePrice = dataColumns[0].InnerText,
                            DifferenceToPreviousDay = dataColumns[9].InnerText,
                            LastPrice = dataColumns[10].InnerText
                        });
                }
            }
