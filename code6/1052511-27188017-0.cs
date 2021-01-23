       ...
       XmlElement subNode = null;
        foreach (DataType item in dataList)
        {
            
            if (jaar != item.Jaar || week != item.Week)
            {
                subNode = document.CreateElement("Groep");
                ...
                rootNode.AppendChild(subNode);
            }
          ...
        }
           
     
