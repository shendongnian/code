    XmlDocument xdoc = new XmlDocument;
    xdoc.Load(savePath);
    XmlNode root = xdoc.DocumentElement;
    // add the namespace
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
    nsmgr.AddNamespace("bml", "http://www.blogml.com/2006/09/BlogML");
    //puts the catagories elements into a list
    XmlNodeList blogCatagories = root.SelectNodes("descendant::bml:post/bml:categories", nsmgr);
    //loop throught list and place the attribute "ref" into a list and traverse each "ref"
    foreach (XmlNode nodeCat in blogCatagories)
    {
        XmlNodeList catagoryids = nodeCat.SelectNodes("descendant::bml:category/@ref", nsmgr);
        foreach (XmlNode nodeID in catagoryids)
        {
            Console.WriteLine(nodeID.InnerText.ToString());
        }
    }
    
