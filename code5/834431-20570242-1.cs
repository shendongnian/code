     private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode fileNode = new TreeNode();
                fileNode.Text = txtFileName.Text; 
                treeView1.SelectedNode.Nodes.Add(fileNode);
                string rootPath = treeView1.SelectedNode.Text; //here is your root path change it if it's wrong
               
                Directory.CreateDirectory(rootPath + "\\" + txtFileName.Text);
                // File.Create(rootPath + "\\" + txtFileName.Text); //if you want create a file instead of direcroty use this
            }
        }
