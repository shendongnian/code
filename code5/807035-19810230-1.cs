    using (var sqlConn = new SqlConnection(connectionString))
    {
        sqlConn.Open();
        const string query = "SELECT orderDate, customerName from MAIN";
        using (var sqlCommand = new SqlCommand(query, sqlConn))
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader())
            {
                var treeNodeCollection = sqlDataReader.SqlToTreeNodeHierarchy(null);
                foreach (TreeNode treeNode in treeNodeCollection)
                {
                    nativeTreeView.Nodes.Add(treeNode);
                }
            }
        }
    }
