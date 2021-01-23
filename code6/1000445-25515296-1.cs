        public void findNode(Node parent, string Id)
        {
            IEnumerable<DataRow> rows = SampleDataTable.Select("ParentNodeID=" + Id);
            foreach (DataRow dr in rows)
            {
                //Create child node
                Node child = new Node();
                child.Name = dr["NodeName"].ToString().Trim();
                parent.Children.Add(child);
                //Add more child nodes recursively
                findNode(child, dr["NodeID"].ToString());
            }
        }
        public void PrintPretty(Node node, string indent, bool last)
        {            
            textBox1.AppendText(indent);
            if (last)
            {
                textBox1.AppendText("\\-");
                indent += "  ";
            }
            else
            {
                textBox1.AppendText("|-");
                indent += "| ";
            }
            textBox1.AppendText(node.Name + Environment.NewLine);
            List<Node> Children = node.Children;
            for (int i = 0; i < Children.Count; i++)
                PrintPretty(Children[i], indent, i == Children.Count - 1);
        }
