        public void Test_PopulateTreeViews()
        {
            var rootNode = new TreeNode();
            var folders = new DataTable();
            folders.Columns.Add("code");
            folders.Columns.Add("description");
            folders.Columns.Add("Attached to");
            folders.Rows.Add("P001", "TEST001", string.Empty);
            folders.Rows.Add("P0001", "TEST002", "P001");
            folders.Rows.Add("P002", "TEST003", null);
            folders.Rows.Add("P00201", "TEST003", "P002");
            folders.Rows.Add("P00222", "TESTXXX", "P002");
            folders.Rows.Add("P002020", "TESTSSS", "P00222");
            PopulateTreeView(rootNode, string.Empty, folders);
        }
        private void PopulateTreeView(TreeNode parentNode, string parentID, DataTable folders)
        {
            foreach (DataRow folder in folders.Rows)
            {
                if (folder["Attached to"].ToString() == parentID)
                {
                    String key = folder["code"].ToString();
                    String text = folder["description"].ToString();
                    var newParentNode = new TreeNode(key, text);
                    parentNode.ChildNodes.Add(newParentNode);
                    PopulateTreeView(newParentNode, folder["code"].ToString(), folders);
                }
            }
        }
    });
