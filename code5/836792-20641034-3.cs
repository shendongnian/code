    private void listBox1_DrawItem(object sender, DrawItemEventArgs e){
      e.DrawBackground();
      if ((e.State & DrawItemState.Focus) == DrawItemState.Focus) 
           e.DrawFocusRectangle();
      //determine the font, if the item is selected, choose a large font size
      //I set it to 15, you can set it yourself accordingly to the selectedItemHeight
      bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
      var font = selected ? new Font(e.Font.FontFamily, 15, e.Font.Style) : e.Font;
      var color = selected ? SystemColors.HighlightText : e.ForeColor;
      //Draw the string, you can also provide some StringFormat to align text, ...
      using(var brush = new SolidBrush(color)){
        e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), font, brush, e.Bounds);
      }
    }
