    using System.Windows.Forms.VisualStyles;
    public class ButtonWithCheckBox : Button {
      public bool OptionChecked { get; set; }
      protected override void OnMouseDown(MouseEventArgs e) {
        if (GetCheckBoxRectangle().Contains(e.Location)) {
          this.OptionChecked = !this.OptionChecked;
          this.Invalidate();
        } else {
          base.OnMouseDown(e);
        }
      }
      protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        CheckBoxRenderer.DrawCheckBox(e.Graphics,
          GetCheckBoxRectangle().Location,
          this.OptionChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
      }
      private Rectangle GetCheckBoxRectangle() {
        Rectangle result = Rectangle.Empty;
        using (Graphics g = this.CreateGraphics()) {
          Size sz = CheckBoxRenderer.GetGlyphSize(g, CheckBoxState.UncheckedNormal);
          result = new Rectangle(new Point(this.ClientSize.Width - (sz.Width + 8), 8), sz);
        }
        return result;
      }
    }
