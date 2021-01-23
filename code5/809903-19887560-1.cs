    private void dataGridView1_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e) {
         if (e.RowIndex > -1 && e.ColumnIndex > -1 && e.Value != null) {
             string value = e.Value.ToString();
             foreach (var s in HighlightStrings) {
                int i = 0;
                while (i < value.Length && (i = value.IndexOf(s,i))!=-1) {
                  if (!e.Handled){
                      e.Handled = true;
                      e.PaintBackground(e.ClipBounds, true);
                   }                        
                   StringFormat sf = StringFormat.GenericTypographic;
                   sf.LineAlignment = StringAlignment.Center; 
                   RectangleF textBounds = GetTextBounds(e.Graphics, 
                                                         value, i, s.Length,
                                                         e.CellBounds, 
                                                         e.CellStyle.Font, sf);
                  //highlight it
                  e.Graphics.FillRectangle(Brushes.Yellow, textBounds);
                  i += s.Length;
                  using (Brush brush = new SolidBrush(e.CellStyle.ForeColor)) {
                     //draw string , don't use PaintContent
                     e.Graphics.DrawString(value, e.CellStyle.Font, brush,
                                           e.CellBounds, sf);
                  }
                }
             }                
         }
     }
     public RectangleF GetTextBounds(Graphics g, string text, 
                                     int subIndex, int subLength, 
                                     RectangleF layout, 
                                     Font font, StringFormat sf) {
          var charRange = new CharacterRange(0, text.Length);
          var subCharRange = new CharacterRange(subIndex, subLength);
          sf.SetMeasurableCharacterRanges(new[]{ charRange, subCharRange });
          var regions = g.MeasureCharacterRanges(text, font, layout, sf);
          return regions.Length < 2 ? RectangleF.Empty : regions[1].GetBounds(g);
     }
