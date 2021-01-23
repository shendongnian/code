    public class MyControl : Control { 
      // ...
      protected override void OnPaint(PaintEventArgs e) { 
        base.OnPaint(e); // Important - makes sure the Paint event fires
        using (var pen = new Pen(Color.Black, 3)) { 
          e.Graphics.DrawRectangle(pen, 0, 0, this.Width, this.Height); 
        }
      }
    }
