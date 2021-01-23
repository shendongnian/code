    XmlDocument dictionary= new XmlDocument();
    dictionary.Load(@"C:\Users\Luka\Documents\Visual Studio 2013\Projects\TSA\TSA\Dictionary.xml");
    XPathNavigator navigator = dictionary.CreateNavigator();
    
    navigator.MoveToChild("dictionary", "");
    navigator.MoveToChild("sentiments", "");
    navigator.MoveToChild("sentiment", "");
    
    navigator.InsertAfter("<sentiment word=\"" + token + "\">" + value + "</sentiment>");
