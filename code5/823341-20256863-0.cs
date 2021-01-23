    for (int i = 0; i < MMDetailsList.Items.Count; i++)
    {
        string text = MMDetailsList.Items[i].SubItems[3].Text;
    	if (!string.IsNullOrEmpty(text))
    	{
    	    if(char.IsLetter(text.Last()))
    		{
    			MessageBox.Show("Last Letter :" +text.Last());
    		}
    	}
    
    }
