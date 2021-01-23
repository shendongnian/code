            foreach (TreeNode child in node.Nodes)
            {
                if (child.Checked == true)
                {
                    MessageBox.Show(child.Text);
                } 
                //MessageBox.Show(child.Text);
                checkNodes(child, check);
            }
        }`
