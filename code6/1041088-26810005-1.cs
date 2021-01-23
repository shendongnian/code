     public class ComboTheme : ComboBox
        {
             new public DrawMode DrawMode { get; set; }
             public Color HighlightColor { get; set; }
    
     
    
        public ComboTheme()
         {
              base.DrawMode = DrawMode.OwnerDrawFixed;
              this.HighlightColor = Color.Red;
              this.DrawItem += new DrawItemEventHandler(ComboTheme_DrawItem); 
         }
        
         public void ComboTheme_DrawItem(object sender, DrawItemEventArgs e)
         {
              if(e.Index > 0)
              {
                   ComboBox box = ((ComboBox)sender);
                   if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                   {
                        e.Graphics.FillRectangle(new SolidBrush(HighlightColor), e.Bounds);
                   }
        
                   else { e.Graphics.FillRectangle(new SolidBrush(box.BackColor), e.Bounds); }
        
                   e.Graphics.DrawString(box.Items[e.Index].ToString(), 
                        e.Font, new SolidBrush(box.ForeColor),
                        new Point(e.Bounds.X, e.Bounds.Y));
                   e.DrawFocusRectangle();
              }
         }
    
    }
