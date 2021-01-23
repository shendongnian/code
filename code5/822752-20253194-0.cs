        public void bind(HtmlNode htmlN, TreeNode treeN)
        {
            StringBuilder result = new StringBuilder();
            switch (htmlN.NodeType)
            {
                case HtmlNodeType.Comment :
                    result.Append(htmlN.InnerText);
                    break;
                case HtmlNodeType.Document :
                    result.Append("root");
                    break;
                case HtmlNodeType.Element :
                    result.Append('<').Append(htmlN.Name).Append('>');
                    break;
                case HtmlNodeType.Text :
                    result.Append(htmlN.InnerText );
                    break;
                default:
                    result.Append("undefined element");
                    break;
            }
            treeN.Text = result.ToString(); 
            treeN.Name = htmlN.Name;
            treeN.Tag = htmlN;
            TreeNode newTN;
            foreach ( HtmlNode node in htmlN.ChildNodes ){
                if ( node.NodeType == HtmlNodeType.Element ||  node.InnerText.Trim().Length > 0 ){
                    newTN = new TreeNode();
                    treeN.Nodes.Add(newTN);
                    bind(node, newTN);
                }
            }
        }
