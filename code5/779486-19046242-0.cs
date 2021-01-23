      for (int column = 0; column < 2; column++)
        {
            for (int count = 0; count < gvList.Rows.Count; count++)
            {
    			if(count < 0)
                oldValue = gvList.Rows[count-1].Cells[column].Text;
                
    			if (oldValue == newValue)
                {
                    gvList.Rows[count].Cells[column].Text = string.Empty;
                }		
    			
                newValue = gvList.Rows[count+1].Cells[column].Text;
            }
        }
