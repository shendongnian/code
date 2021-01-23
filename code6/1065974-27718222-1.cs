    private Collection<string> tickerAtributesList=new Collection<string>();
    tickerAtributesList.add("date");
    tickerAtributesList.add("title");
    tickerAtributesList.add("description");
    XmlNodeList nodes = xmlDoc.SelectNodes("rss/channel/item");
    keyValuePair = new Collection<DynamicDictionary>();
            foreach (XmlNode node in nodes)
            {
                DynamicDictionary tempDynamicDictionary = new DynamicDictionary();
                foreach (string tickerAtribute in tickerAtributesList)
                {
                    tempDynamicDictionary.AddKeyValuePair(tickerAtribute, ParseDocElements(node, tickerAtribute));
                }
                keyValuePair.Add(tempDynamicDictionary);
            }
