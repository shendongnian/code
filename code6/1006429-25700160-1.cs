    public class TextBoxWithLabel : TextBox {        
          [DllImport("user32.dll")]
          private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        
          Label label = new Label();
        
          public TextBoxWithLabel() {
            label.BackColor = Color.LightGray;
            label.Cursor = Cursors.Default;
            label.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(label);
          }
        
          private int LabelWidth() {
            return TextRenderer.MeasureText(label.Text, label.Font).Width;
          }
        
          public string LabelText {
            get { return label.Text; }
            set {
              label.Text = value;
              SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(LabelWidth() << 16));
              OnResize(EventArgs.Empty);
            }
          }
        
          protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            int labelWidth = LabelWidth();
            label.Left = this.ClientSize.Width - labelWidth;
            label.Top = (this.ClientSize.Height / 2) - (label.Height / 2);
            label.Width = labelWidth;
            label.Height = this.ClientSize.Height;
          }
        }
