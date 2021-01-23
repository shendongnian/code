    listBox1.DrawMode = DrawMode.OwnerDrawVariable;
     private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e) {
         if (e.Index == 2) e.ItemHeight = 50;
     }
     private void listBox1_DrawItem (object sender, DrawItemEventArgs e) {
       e.DrawBackground();
       e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
     }
