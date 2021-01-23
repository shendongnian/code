        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                ListViewItem lvItem = listView1.HitTest(e.Location).Item;
                if (lvItem != null)
                    lvItem.Selected = true;
                if (listView1.SelectedItems.Count > 1)
                {
                    Int32 firstSelected = listView1.SelectedItems[0].Index;
                    Int32 lastSelected = listView1.SelectedItems[listView1.SelectedItems.Count-1].Index;
                    foreach(ListViewItem tempLvItem in listView1.Items)
                    {
                        if(tempLvItem.Index >= firstSelected && tempLvItem.Index <= lastSelected)
                            tempLvItem.Selected = true;
                    }    
                }
            }
        }
