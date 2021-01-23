     private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                OpenFileDialog dlg = new OpenFileDialog()
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TreeNode fileNode = new TreeNode();
                    fileNode.Text = dlg.SafeFileName; //if you want full name use dlg.FileName
                    treeView1.SelectedNode.Nodes.Add(fileNode);
                }
            }
        }
