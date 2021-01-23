    private void listView1_DrawItem(object sender, DrawItemEventArgs e)
    {
       if (e.Item.Text != itemToColor ) e.DrawDefault = true;
       else
       {
         e.DrawBackground();
         // e.Graphics.FillRectangle(new SolidBrush(Color.Olive), e.Bounds); // optional
         e.Graphics.DrawString(itemToColor, listView1.Font, 
                               Brushes.Red, new PointF(e.Bounds.X, e.Bounds.Y));
       }
    }
