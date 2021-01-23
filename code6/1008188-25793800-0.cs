        private void tvFileMan_AfterCheck(object sender, TreeViewEventArgs e)
        {
            getFileAndColumns();
            if (e.Node.Nodes.Count > 0)
            {
               //this.CheckAllChildNodes(e.Node, e.Node.Checked);
                // Checked a file so get fields and check all fields except subfiles.
                e.Node.Expand();
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    if (tn.Nodes.Count.Equals(0))
                        tn.Checked = e.Node.Checked;
                }
                getChildNodesToGrid();
            }
            else
            {
                e.Node.Expand();
    
                    //if (tn.Nodes.Count.Equals(0))
                    if (e.Node.Checked)
                    {
                        //tn.Checked = e.Node.Checked;
                        getChildNodesToGrid();
                    }
    
            }
    
       private DataTable getFieldsTable()
        {
            //original
            DataTable dt = new DataTable();
            dt.Columns.Add("ColumnName");
            dt.Columns.Add("FMFieldName");
            dt.Columns.Add("FMFieldNumber");
            dt.Columns.Add("FMFileNumber");
            dt.Columns.Add("FMFieldType");
            dt.Columns.Add("ResolvedValue");
            dt.Columns.Add("PointsToFileNumber");
            TreeNode fileNode = tvFileMan.SelectedNode;
            int cnt = 0;
            foreach (TreeNode tn in fileNode.Nodes)
            {
                if (tn.Nodes.Count == 0)
                {   
                    if (fileNode.Nodes[cnt].Checked)
                    {
                     DataRow dr = dt.NewRow();
    
                    dr["FMFieldName"] = tn.Text.Substring(tn.Text.IndexOf("  - ") + 4);
                    dr["FMFieldNumber"] = tn.Tag.ToString();
                    dr["FMFileNumber"] = tn.Parent.Tag.ToString();
                    dr["ColumnName"] = suggestName(tn.Text.Substring(tn.Text.IndexOf("  - ") + 4));
                    //added by TEA 9/3/14 to get PointsToFileNumber in DataGrid
                    if (dr["PointsToFileNumber"].ToString().Length > 0)
                    {
                        dr["ColumnName"] = suggestName(tn.Text.Substring(tn.Text.IndexOf("  - ") + 4) + "txt");
                    }
                    dt.Rows.Add(dr);
                    }
                    cnt++;
                }
            }
            return dt;
    
        }
       private void getFileAndColumns()
        {
            label4.Visible = false;
            label5.Visible = false;
            btAllFields.Visible = false;
            cbComputed.Checked = false;
            TreeNode node = tvFileMan.SelectedNode;
            if (node == null) return;
            // Is it a File or Field?
            if (node.Index == 0) return;
    
            if (node.Nodes.Count > 0)
            {
                // FileManFile selected.
                // Check AttributeMap for this file. If found, fill in textboxes with that info.
    
                // Otherwise, suggest a name for the table.
                tbFileNumber.Text = node.Tag.ToString();
                tbFileName.Text = node.Text.Substring(node.Text.IndexOf("  - ") + 4);
                tbTableName.Text = "xxxx." + (suggestName(tbFileName.Text) + "F" + tbFileNumber.Text.Replace('.', 'x'));
                label4.Text = "To select all fields push button to the right. \nOtherwise double-click fields to add them one at a time.";
                label4.Visible = true;
                btAllFields.Visible = true;
                dgvColumns.DataSource = null;
                dgvPKIENS.DataSource = getPKIENSTable();
                getPKIENSIDs();
            }
            else
            {
                // FileMan Field selected.
            }
    
    
        }
