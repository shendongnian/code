    private void listView_SelectedIndexChanged(object sender, EventArgs e)
    		{
    			if(listView.SelectedIndices.Count > 1)
    			{
    				MessageBox.Show("Multiple rows selected!");
    			}
    		}  
