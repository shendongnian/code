    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        // DrawItemEventArgs::Index gives you the index of the item being drawn.
        var itemText = listBox1.Items[e.Index].ToString();
        // Get a red brush if the item is a DateTime less than an hour away, or a black
        // brush otherwise.
        DateTime itemTime, deadline = DateTime.Now.AddHours(1);
        var brush = (DateTime.TryParse(itemText, out itemTime) && itemTime < deadline) ? Brushes.Red : Brushes.Black;
        // Several other members of DrawItemEventArgs used here; see class documentation.
        e.DrawBackground();
        e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
    }
