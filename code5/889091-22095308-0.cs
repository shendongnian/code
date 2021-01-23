    ListBox1.Items.Add(ddlFilter.SelectedItem.Text + " " + txtStaff.Text);
    ListBox1.DrawMode = DrawMode.OwnerDrawFixed;
    private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        e.Graphics.DrawString(ListBox1.Items[e.Index].ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, e.Bounds);
        e.DrawFocusRectangle();
    }
