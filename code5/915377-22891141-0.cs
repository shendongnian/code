      private void button1_Click(object sender, EventArgs e)
        {
            if(listBoxFrom.SelectedItems.Count>0)
            {
              for (int x = listBoxFrom.SelectedIndices.Count - 1; x >= 0; x--)
                {
                    int idx = listBoxFrom.SelectedIndices[x];
                    listBoxTo.Items.Add(listBoxFrom.Items[idx]);
                    listBoxFrom.Items.RemoveAt(idx);
                } 
                
            }
        }
