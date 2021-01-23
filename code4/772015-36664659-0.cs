     static TreeViewItem item;
        static public void Show(TreeView tree)
        {
            DataSet dsSet = Class.GetDS();
            for (int i = 0; dsSet.Tables[0].Rows.Count > i; i++)
            {
                item = new TreeViewItem();
                item.Header = dsSet.Tables[0].Rows[i][1];
                for (int j = 0; j < 2; j++)
                {
                    item.Items.Add("Monitor");
                    item.Items.Add("LapTop");
                }
                tree.Items.Add(item);
            }
        }
    Show(treeView);
