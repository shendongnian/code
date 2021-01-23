            SampleDataTable = new DataTable();
            SampleDataTable.Columns.Add("NodeName", typeof(string));
            SampleDataTable.Columns.Add("NodeID", typeof(int));
            SampleDataTable.Columns.Add("ParentNodeID", typeof(int));
            //Insert sample data to this table
            SampleDataTable.Rows.Add("Node1", 1, 0);
            SampleDataTable.Rows.Add("Node2", 2, 0);
            SampleDataTable.Rows.Add("Node3", 3, 2);
            SampleDataTable.Rows.Add("Node4", 4, 3);
            SampleDataTable.Rows.Add("Node5", 5, 0);
            SampleDataTable.Rows.Add("Item1", 6, 1);
            SampleDataTable.Rows.Add("Item2", 7, 1);
            SampleDataTable.Rows.Add("Item3", 8, 2);
            SampleDataTable.Rows.Add("Item4", 9, 2);
            SampleDataTable.Rows.Add("Item5", 10, 3);
            SampleDataTable.Rows.Add("Item6", 11, 4);
            SampleDataTable.Rows.Add("Item7", 12, 5);
            Node tree = new Node();
            foreach (DataRow dr in SampleDataTable.Rows)
            {
                if ((int)dr["ParentNodeID"] == 0)
                {
                    Node parentNode = new Node();
                    parentNode.Name = dr["NodeName"].ToString();
                    string value = dr["NodeID"].ToString();
                    tree.Children.Add(parentNode);
                    findNode(parentNode, value);
                }
            }
            PrintPretty(tree, "   ", true);
