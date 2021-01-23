    XElement root = XElement.Load("xmlfile1.xml");
    var allNodes = root.DescendantNodesAndSelf();
    int maxNameLength = allNodes.OfType<XElement>()
        .Select(x => x.Name.LocalName.Length)
        .Max();
    foreach (XNode x in allNodes)
    {
        XElement node = x as XElement;
        if (node != null)
        {
            int numAncestors = node.Ancestors().Count();
    
            XText textNode = node.Nodes().OfType<XText>().FirstOrDefault();
            string text = "";
            if (textNode != null)
                text = textNode.Value.Trim();
    
            string name = node.Name.LocalName;
            // PadLeft() subtracts the string.Length from the padding
            // so add its length to the padding amount
            string left = name.PadLeft(numAncestors * 5 + name.Length);
            // PadRight() wasn't giving the expected results 
            // so improvised with the following
            string right = left + "".PadLeft(maxNameLength + 5 - name.Length);
    
            Console.WriteLine("{0} = {1}", right, text);
        }
    }
