        private void ReloadTreeFromXmlDocument(XmlDocument dom)
        {
            treeView1.BeginUpdate();
            try
            {
                XmlTreeViewHelper.AddOrMergeNodes(treeView1.Nodes, dom.DocumentElement.ChildNodes, GetTreeNodeName, GetTreeNodeText, FilterNode);
            }
            finally
            {
                treeView1.EndUpdate();
            }
        }
        static string GetTreeNodeName(XmlNode inXmlNode)
        {
            string text = GetAttributeText(inXmlNode, "name");
            if (string.IsNullOrEmpty(text))
                text = inXmlNode.Name;
            return text;
        }
        static string GetTreeNodeText(XmlNode inXmlNode)
        {
            string text = GetAttributeText(inXmlNode, "name");
            if (string.IsNullOrEmpty(text))
            {
                if (inXmlNode.HasChildNodes)
                {
                    text = inXmlNode.Name;
                }
                else
                {
                    text = (inXmlNode.OuterXml).Trim();
                }
            }
            return text;
        }
    
        string filter = "_start"; // Reload when this changes.
        bool FilterNode(XmlNode inXmlNode)
        {
            return FilterNode(inXmlNode, filter);
        }
        bool FilterNode(XmlNode inXmlNode, string nodeNameFilter)
        {
            if (inXmlNode.Name == "namespace" && inXmlNode.ChildNodes.Count == 0 && string.IsNullOrEmpty(GetAttributeText(inXmlNode, "name")))
                return false;
            if (!string.IsNullOrEmpty(nodeNameFilter))
            {
                string text = GetTreeNodeText(inXmlNode);
                if (text.Contains(nodeNameFilter))
                    return false;
            }
            return true;
        }
