    bool notFound = true;
    while (doc.Read())
    {
        if ((doc.NodeType == XmlNodeType.Element) && (doc.Name.Equals("var")))
        {
            if (newdoc.HasAttributes)
            {
                String vname = newdoc.GetAttribute("name");
                String vno = newdoc.GetAttribute("number");
                String pname = newdoc.GetAttribute("p-names");
                //File.AppendAllText(@"loca\Var.txt", vname + pname + Environment.NewLine);
            }
        }
        else if(notFound && doc.NodeType == XmlNodeType.Element && doc.Name.Equals("title"))
        {
             notFound = false;
             //do whatever you need to do here w/ this node
        }
    }
