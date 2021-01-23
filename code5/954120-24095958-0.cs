    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenu m = new ContextMenu();
            m.MenuItems.Clear(); // clear menu before adding new items
            m.MenuItems.Add(new MenuItem("Cut"));
            m.MenuItems.Add(new MenuItem("Copy"));
            m.MenuItems.Add(new MenuItem("Paste"));
            int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0)
            {
                m.MenuItems.Add(new MenuItem(string.Format("Row number {0}", currentMouseOverRow.ToString())));
                m.MenuItems[m.MenuItems.Count - 1].OwnerDraw = true;
                m.MenuItems[m.MenuItems.Count - 1].DrawItem += Cm_DrawItem;
                m.MenuItems[m.MenuItems.Count - 1].MeasureItem += MeasureMenuItem;
            }
            m.Show(dataGridView1, new Point(e.X, e.Y));
        }
    }
