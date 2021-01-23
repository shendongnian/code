    listView1.MouseDown += listView1_MouseDown;
    void listView1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        if (listView1.GetItemAt(e.X, e.Y) is ListViewItem) {
          ContextMenu1.Show(Cursor.Position);
        } else {
          ContextMenu2.Show(Cursor.Position);
        }
      }
    }
