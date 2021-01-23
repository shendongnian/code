    private void btn_Delete_Click(object sender, EventArgs e)
    {
        if (lstb_seriesName.SelectedItems.Count <= 0)
            MessageBox.Show("You need to select an item to delete first!");
        else
        {
            var indexesToRemove = lstb_seriesName.SelectedIndices;
            foreach(var index in indexesToRemove)
            {
                lstb_seriesName.Items.RemoveAt(index);
                lstb_seriesDay.Items.RemoveAt(index);
                lstb_seriesTime.Items.RemoveAt(index);
                lstb_seriesActive.Items.RemoveAt(index);
            }    
            MessageBox.Show("Program deleted!");
        }    
    }    
