        XmlNodeList elemList = doc.GetElementsByTagName("RcsTweet");
        for (int i = 0; i < elemList.Count; i++)
        {
            string name = elemList[i].Attributes["Name"].Value;
            string handle = elemList[i].Attributes["Handle"].Value;
            string tweet = elemList[i].Attributes["Tweet"].Value;
        }
