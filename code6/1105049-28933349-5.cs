    ListBox1.DrawMode = DrawMode.OwnerDrawVariable;
    private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e) {
        int i = e.Index;
        float heightLine = 10.0f;
        string lines = listBox1.Items[i].ToString()Split(new string[] {Environment.NewLine},StringSplitOptions.None).Length;
        e.ItemHeight = (int) Math.Ceil(heightLine*itemi);
    }
    private void listBox1_DrawItem (object sender, DrawItemEventArgs e) {
       e.DrawBackground();
       e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
    }
    ListBox1.MeasureItem += listBox1_MeasureItem;
    ListBox1.DrawItem += listBox1_DrawItem;
