    if (targetCell.Value == null)
    {
    	targetCell.Value = e.Data.GetData(DataFormats.Text);
    }
    else
    {
    	if (targetCell.Value.ToString().Contains(e.Data.GetData(DataFormats.Text).ToString().Split(' ')[1]))
    	{
    
    	}
    	else
    	{
    		targetCell.Value = targetCell.Value.ToString().Split(' ')[1] + System.Environment.NewLine + e.Data.GetData(DataFormats.Text);
    
    	}
    }
