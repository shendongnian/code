    string itemToColor = "File already exist and was not overwritten.";
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
       if (e.Item.Text != itemToColor ) e.DrawDefault = true;
       else
       {
         e.DrawBackground();
         e.Graphics.FillRectangle(new SolidBrush(Color.Olive), e.Bounds);
         e.Graphics.DrawString(itemToColor, e.Font, 
                               Brushes.Red, new PointF(e.Bounds.X, e.Bounds.Y));
       }
    }
