    private void listView_SelectedIndexChanged(object sender, EventArgs e)
    		{
    			if(listViewStundenzettel.SelectedIndices.Count > 1)
    			{
    				MessageBox.Show("Multiple rows selected!");
    			}
    		}  
