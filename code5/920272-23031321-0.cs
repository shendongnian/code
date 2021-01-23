     public class HighlightableRTB : RichTextBox
     {
         // You should probably find a way to calculate this, as each line could have a different height.
         private int LineHeight = 15; 
         public HighlightableRTB()
         {
             HighlightColor = Color.Yellow;
         }
        [Category("Custom"),
        Description("Specifies the highlight color.")]
         public Color HighlightColor { get; set; }
    
         protected override void OnSelectionChanged(EventArgs e)
         {
             base.OnSelectionChanged(e);
             this.Invalidate();
         }
    
         private const int WM_PAINT = 15;
    
         protected override void WndProc(ref Message m)
         {
             if (m.Msg == WM_PAINT)
             {
                 var selectLength = this.SelectionLength;
                 var selectStart = this.SelectionStart;
    
                 this.Invalidate();
                 base.WndProc(ref m);
    
                 if (selectLength > 0) return;   // Hides the highlight if the user is selecting something
                 using (Graphics g = Graphics.FromHwnd(this.Handle))
                 {
                     Brush b = new SolidBrush(Color.FromArgb(50, HighlightColor));
                     var line = this.GetLineFromCharIndex(selectStart);
                     var loc = this.GetPositionFromCharIndex(this.GetFirstCharIndexFromLine(line));
                     g.FillRectangle(b, new Rectangle(loc, new Size(this.Width, LineHeight)));
                 }
             }
             else
             {
                 base.WndProc(ref m);
             }
         }
     }
