        Point mousePos = listView1.PointToClient( Control.MousePosition );
        ListViewHitTestInfo htInfo = listView1.HitTest(mousePos);
        if (htInfo.Item == null) return;
        int itemIndex = htInfo.Item.Index;
        int subItemIndex = htInfo.Item.SubItems.IndexOf(htInfo.SubItem);
        if (subItemIndex == yourLinkColumnIndex)
        {
            try
            {
                string linkOn = "linkto:" +  htInfo.Item.SubItems[subItemIndex].Text;
                System.Diagnostics.Process.Start(linkOn);
            } catch (Win32Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message);
            }
        }
