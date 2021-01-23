    using System.Drawing;
    using System.Windows.Forms;
    namespace <YourNameSpaceHere>
    {
        class TickLabel : Control
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                int x = 0;
                int[] widths = _MeasureWidths(Text);
                using (Pen pen = new Pen(ForeColor))
                {
                    for (int i = 0; i < Text.Length; i++)
                    {
                        TextRenderer.DrawText(e.Graphics, Text.Substring(i, 1), Font, new Point(x, 0), ForeColor);
                        x += widths[i];
                        e.Graphics.DrawLine(pen, x, ClientSize.Height, x, ClientSize.Height - 10);
                    }
                }
            }
            private int[] _MeasureWidths(string text)
            {
                int[] widths = new int[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    widths[i] = TextRenderer.MeasureText(text.Substring(i, 1), Font, ClientSize, TextFormatFlags.NoPadding).Width;
                }
                return widths;
            }
        }
    }
