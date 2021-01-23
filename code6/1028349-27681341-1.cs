        Int32 firstClickItemIndex = 0;
		
		public Boolean numInRange(Int32 num, Int32 first, Int32 last)
        {
            return first <= num && num <= last;
        }		
		
		private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
				foreach (ListViewItem lvItem in listView1.Items)
					lvItem.Selected = true;
			}
		}
		private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left && listView1.HitTest(e.Location).Item != null)
                firstClickItemIndex = listView1.HitTest(e.Location).Item.Index;            
        }
		
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                ListViewItem lvItem = listView1.HitTest(e.Location).Item;
                if (lvItem != null)
                {
                    lvItem.Selected = true;
                    if (listView1.SelectedItems.Count > 1)
                    {
                        Int32 firstSelected = listView1.SelectedItems[0].Index;
                        Int32 lastSelected = listView1.SelectedItems[listView1.SelectedItems.Count - 1].Index;
                        foreach (ListViewItem tempLvItem in listView1.Items)
                        {
                            if (numInRange(tempLvItem.Index, firstSelected, lastSelected) && (numInRange(tempLvItem.Index, lvItem.Index, firstClickItemIndex) || numInRange(tempLvItem.Index, firstClickItemIndex, lvItem.Index)))
                            {
                                tempLvItem.Selected = true;
                            }
                            else
                            {
                                tempLvItem.Selected = false;
                            }
                        }
                    }
                }
            }
        }
