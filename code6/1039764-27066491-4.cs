        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            XPathNavigator methodNode = GetMethodNode(actionDescriptor);
            if (methodNode != null)
            {
                XPathNavigator summaryNode = methodNode.SelectSingleNode("summary");
                if (summaryNode != null)
                {
                    return string.Format("<summaries>{0}</summaries>", methodNode.InnerXml);
                }
            }
            return null;
        }
