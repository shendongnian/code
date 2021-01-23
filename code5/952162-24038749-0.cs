private void listView1_MouseClick(object sender, MouseEventArgs e) {
    if (e.Button == MouseButtons.Right) {
        var item = listView1.GetItemAt(e.Location.X, e.Location.Y);
        if (item != null) {
            menuItemSelected.Show(Cursor.Position);
            menuItemSelected.Tag = item.Tag;
        }
    }
}
