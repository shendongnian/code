            ListViewHitTestInfo hit = listView1.HitTest(e.Location);
            if (hit.Item != null)
            {
            MessageBox.Show(hit.Item.Text + " " + hit.Item.SubItems[1].Text + " " + hit.Item.SubItems[2].Text + " ");       
            };
