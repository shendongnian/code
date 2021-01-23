        public static HtmlElement GetChild(HtmlElement el, DocNode node)
        {
            // Find corresponding child of the elemnt 
            // based on the name and position of the node
            int childPos = 0;
            foreach (HtmlElement child in el.Children)
            {
                if (child.TagName.Equals(node.Name, 
                   StringComparison.OrdinalIgnoreCase))
                {
                    if (childPos == node.Pos)
                    {
                        return child;
                    }
                    childPos++;
                }                
            }
            return null;
        }
