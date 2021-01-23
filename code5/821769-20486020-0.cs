        //Removing whitespace created 
                
       if (xnode.NextSibling != null && xnode.NextSibling.NodeType == XmlNodeType.Whitespace)
          {
                xnode.ParentNode.RemoveChild(xnode.NextSibling);
          }
