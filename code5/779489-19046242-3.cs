     for (int column = 0; column < 2; column++)
        {
            for (int row = 0; row < gvList.Rows.Count; row++)
            {		
    		
    			if(gvList.Rows[row].Cells[column].Text != "")
    				oldValue = gvList.Rows[row].Cells[column].Text;
                
    			if (oldValue == newValue)
                {
                    gvList.Rows[row].Cells[column].Text = string.Empty;
                }		
    			
    			if(row+1 < gvList.Rows.Count)
                 newValue = gvList.Rows[row+1].Cells[column].Text;
            }
        }
