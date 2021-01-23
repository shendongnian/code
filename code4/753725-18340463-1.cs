        private void timer1_Tick(object sender, EventArgs e)
        {
            // before adding
            if (listView1.SelectedIndices.Count > 0)
            {
                if (!listView1.Items[listView1.SelectedIndices[0]].Bounds.IntersectsWith(listView1.ClientRectangle))
                    listView1.TopItem.Focused = true;
                else
                    listView1.Items[listView1.SelectedIndices[0]].Focused = true;
            }
            // add item
            listView1.VirtualListSize++;
        }
