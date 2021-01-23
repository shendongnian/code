    XmlNode root = doc.FirstChild;
    //* the document has one root element "ActueleVertrekTijden"
    //* the root element has multiple child nodes "VertrekkendeTrein" 
    XmlNodeList nodelist1 = root.ChildNodes;
    for (int i=0; i<nodelist1.Count; i++)
    {
      XmlNodeList nodelist2 = nodelist1[i].ChildNodes;
      //* for each child node get all of all of child nodes,
      //* that is where you need to get the text within each one of them
      foreach (XmlNode node in nodeList2)
      {
        switch (node.Name)
        {
                case "VertrekTijd": 
      string vertrek1 = node.InnerText; 
      break;
      case "VertrekVertragingsTekst": 
      string vertraging1 = node.InnerText; 
      break;
      case "EindBestemming": 
      string eindbest1 = node.InnerText; 
      break;
      case "TreinSoort": 
      string treinsoort1 = node.InnerText; 
      break;
      case "RouteTekst": 
      string route1 = node.InnerText; 
      break;
      case "VertrekSpoor": 
      string spoor1 = node.InnerText; 
      break;
      case "Opmerkingen": 
      XmlNode OpNode = node.FirstChild;
      if(OpNode!=null)
      {
        string opmerking1 = OpNode.InnerText; 
      }
      break;
      }
      }
    }
