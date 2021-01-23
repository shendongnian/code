    int item_l = list.Items[1].SubItems[2].Bounds.Left + 3;
    int item_t = list.Items[1].SubItems[2].Bounds.Top + 29;
    int item_w = list.Items[1].SubItems[2].Bounds.Width - 1;
    int item_h = list.Items[1].SubItems[2].Bounds.Height - 1;
    
    ListView listt = new ListView();
    Controls.Add(listt);
    listt.BringToFront();
    listt.Bounds = new Rectangle(new Point(item_l, item_t), new Size(item_w, item_h));
