    var elements = XElement.Parse(@"<name>
        TESTING
          <given>GIVENNAME2</given>
          <family>FAMILYNAME</family>
        </name>");
    
    // grab just the first text node for your specific case
    // (since we know the structure)
    var text = elements.Nodes().First().ToString();
    Console.WriteLine(text);
    
    // general approach to inspect all nodes
    foreach (var node in elements.Nodes())
    {
        switch (node.NodeType)
        {
            case XmlNodeType.Text:
                var xtext = (XText)node; // could just ToString() it
                Console.WriteLine("{0} : {1}", node.NodeType, xtext.Value);
                break;
            case XmlNodeType.Element:
                var xelement = (XElement)node;
                Console.WriteLine("{0} : {1} : {2}", node.NodeType,
                    xelement.Name, xelement.Value);
                break;
            default:
                Console.WriteLine(node);
                break;
        }    
    }
