    //The DataTable is now a private member variable and is accessible in the tvFileMan_AfterCheck event 
    private DataTable dt = getFieldsTable();
    
    private void getChildNodesToGrid()
       {
            dgvColumns.DataSource = dt; //this binds the DataTable to the GridView
            getAttributeSIDs();
        }
    
    private void tvFileMan_AfterCheck(object sender, TreeViewEventArgs e)
        {
            getFileAndColumns();
            if (e.Node.Nodes.Count > 0)
            {
               this.CheckAllChildNodes(e.Node, e.Node.Checked);
                e.Node.Expand();
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (tn.Nodes.Count.Equals(0))
                        tn.Checked = e.Node.Checked;
                }
    
                //HERE Add the treenode(s) to the DataTable
                DataRow dr = dt.NewRow();
                dr[0] = "e.Node.Text";
                dt.Rows.Add(dr);
    
                getChildNodesToGrid();
     }       
