    private void PopulateTreeView()
        {
            // sorts the fields by ascending order.
            frmCheckOut.checkedOutItem.SortList();
            // Clears the Tree View so there is no duplicate entries.
            tvInventory.Nodes.Clear();
            
            TreeNode treeNode = new TreeNode();
            foreach(CheckOutItem item in frmCheckOut.checkedOutItem.itemCollection)
           {
                treeNode = new TreeNode(item.EmpNumber + " " + item.LastName + ", " + item.FirstName + "<" + item.Email + ">");
                tvInventory.Nodes.Add(treeNode);
            }
            AddChildNodes();
        }
        private void AddChildNodes()
        {
            TreeNode date = new TreeNode();
            TreeNode[] nodeArray = new TreeNode[1];
            TreeNode itemDescription = new TreeNode();
            TreeNode[] nodeArray2 = new TreeNode[1];
            for (int i = 0; i < tvInventory.Nodes.Count; i++)
            {
                foreach (CheckOutItem item in frmCheckOut.checkedOutItem.itemCollection)
                {
                    foreach (Hardware h in item.hardware)
                    {
                        date = new TreeNode(h.Date);
                        nodeArray = new TreeNode[] { date };
                        itemDescription = new TreeNode(h.HName + ": " + h.TagNumber, nodeArray);
                        tvInventory.Nodes[i].Nodes.Add(itemDescription);
                    }
                }
            }
        }
