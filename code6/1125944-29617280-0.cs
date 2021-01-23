    private void queryXML2()
    {
        string xmlPath = "JapaneseEnglishData.xml";
        XDocument XDoc = XDocument.Load(xmlPath);
        var listOEnglish = from wordList in XDoc.Root.Elements("Word")
                           select wordList.Element("English").Value;
        listBx.ItemsSource = listOEnglish.ToList();
    }
