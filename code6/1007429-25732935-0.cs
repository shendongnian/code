    public void HighlightDuplicate(GridView grv)
    {
        //use the currentRow to compare against
        for (int currentRow = 0; currentRow < grv.Rows.Count - 1; currentRow++)
        {
            GridViewRow rowToCompare = grv.Rows[currentRow];
            //specify otherRow as currentRow + 1
            //This forloop loops over more rows then exist
            for (int otherRow = currentRow + 1; otherRow < grv.Rows.Count -1; otherRow++)
            {
                GridViewRow row = grv.Rows[otherRow];
                bool duplicateRow = true;
                //compare cell ENVA_APP_ID between the two rows
                if (!rowToCompare.Cells["ENVA_APP_ID"].Text.Equals(row.Cells["ENVA_APP_ID"].Text))
                {
                    duplicateRow = false;
                    break;
                }
                //highlight both the currentRow and otherRow if ENVA_APP_ID matches 
                if (duplicateRow)
                {
                    rowToCompare.BackColor = System.Drawing.Color.Red;                    
                }
            }
        }
    }
