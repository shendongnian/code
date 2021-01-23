    private void AtribesAndInnerTexts(string pathToFile)
    {
      var doc = new System.Xml.XmlDocument();
      doc.LoadXml(File.ReadAllText(pathToFile));
        // desired node in this case UnitTestResult
      var UnitTestResults = doc.GetElementsByTagName("UnitTestResult");
        foreach (var unitTestResult in UnitTestResults)
        {
            Console.WriteLine(((XmlElement) unitTestResult).GetAttribute("executionId"));
            Console.WriteLine(((XmlElement) unitTestResult).InnerText);
        }
    }
