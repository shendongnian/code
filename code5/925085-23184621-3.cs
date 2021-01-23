    public class RadioButtonBoxPainter:IDisposable
    {
        public readonly ListBox ListBox;
        public RadioButtonBoxPainter(ListBox ListBox)
        {
            this.ListBox = ListBox;
            ListBox.DrawMode = DrawMode.OwnerDrawFixed;
            ListBox.DrawItem += ListBox_DrawItem;
        }
        void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            Rectangle r = e.Bounds;
            r.Width=r.Height;
            bool selected= (e.State & DrawItemState.Selected) > 0;
            e.DrawBackground();
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ControlPaint.DrawRadioButton(e.Graphics, r, selected ? ButtonState.Checked : ButtonState.Normal);
            r.X = r.Right + 2;
            r.Width = e.Bounds.Width - r.X;
            string txt;
            if (ListBox.Site != null && ListBox.Site.DesignMode && e.Index >= ListBox.Items.Count)
                txt = ListBox.Name;
            else
                txt = ListBox.GetItemText(ListBox.Items[e.Index]);
            using (var b = new SolidBrush(e.ForeColor))
                e.Graphics.DrawString(txt, e.Font, b, r);
            if (selected)
            {
                r = e.Bounds;
                r.Width--; r.Height--;
                e.Graphics.DrawRectangle(Pens.DarkBlue, r);
            }
        }
        public void Dispose()
        {
            ListBox.DrawItem -= ListBox_DrawItem;
        }
    }
