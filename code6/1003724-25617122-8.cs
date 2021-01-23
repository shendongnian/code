    protected void FilterSelected_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rowItem in gridview1.Rows )
        {
            var myCheckbox = rowItem.Cells[0].Controls[1] as CheckBox; // ONLY if your Checkbox in the FIRST column!!!!
    
                if (myCheckbox != null && !myCheckbox.Checked)
                {
                    rowItem.Visible = false;
                }   
            }
        }
    }
