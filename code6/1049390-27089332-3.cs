        private void RemoveChildNodes(TreeNode aNode)
        {
            //get the id from the node (I don't know where id is for our purpose I'll say it is in tag
            XDocument list = DeleteID(@"c:\temp\test.xml", (string)aNode.Tag);
            //reload the tree here
            var messageResult = MessageBox.Show("Delete from XML too ?", "Alerte de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageResult == System.Windows.Forms.DialogResult.Yes)
            {
                list.Save(@"c:\temp\test.xml");
            }
        }
