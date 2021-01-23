        private void TraverseNodes(XmlNodeList nodes) {
            Boolean haveValue = false;
            foreach (XmlNode node in nodes) {
                // Do something with the node.
                if (!node.Name.Equals("#text")) {
                    nodeName = node.Name;
                    capturedNode = node;
                    haveValue = false;
                } else {
                    nodeValue = node.Value;
                    haveValue = true;
                }
                if (haveValue) {
                    Debug.WriteLine("-----------------------------------------------------");
                    Debug.WriteLine("GetRecursiveList - capturedNode: " + capturedNode.Name);
                    Debug.WriteLine("GetRecursiveList capturedNode Parent: " + capturedNode.ParentNode.Name);
                    Debug.WriteLine("GetRecursiveList NAME|VALUE: " + nodeName + " | " + nodeValue);
                    string path = getNodePath(capturedNode);
                    Debug.WriteLine("GetRecursiveList capturedNode PATH: " + path);
                    //THIS IS HOW YOU GET THE NODE IN THE OTHER XML
                    XElement element = xmlNbidData.XPathSelectElement(path);
                    //AND THEN SET ITS VALUE !!!
                    element.Value = nodeValue;
                }
                TraverseNodes(node.ChildNodes);
            }
        }
