        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Controls.Clear();
            int toggleblocsize = (int)this.Size.Width / 6;
            int indent = 23;
            int labelx = 2;
            // Declare and instantiate a new pen.
            SolidBrush OffPen = new SolidBrush(this.OffColor);
            SolidBrush OnPen = new SolidBrush(this.OnColor);
            Rectangle texttangle = new Rectangle(new Point(labelx, 0), new Size(indent - labelx, this.Size.Height));
            SolidBrush BackgroundBrush = new SolidBrush(this.Parent.BackColor);
            SolidBrush ToggleBrush = new SolidBrush(SystemColors.ControlText);
            SolidBrush TextBrush = new SolidBrush(SystemColors.ControlText);
            Pen ControlDarkPen = new Pen(SystemColors.ControlDark);
            Pen ControlPen = new Pen(SystemColors.Control);
            e.Graphics.FillRectangle(BackgroundBrush, 0, 0, this.Size.Width, this.Size.Height);
            e.Graphics.FillRectangle(new SolidBrush(BackColor), indent, 0, this.Size.Width - indent, this.Size.Height);
            e.Graphics.DrawRectangle(ControlDarkPen, indent, -0, this.Size.Width - (indent + 1), this.Size.Height - 1);
            if (!this.Enabled)
            {
                OffPen = new SolidBrush(SystemColors.Control);
                OnPen = new SolidBrush(SystemColors.Control);
                ToggleBrush = new SolidBrush(SystemColors.ControlDark);
                TextBrush = new SolidBrush(SystemColors.Control);
            }
            if (this._Checked)
            {
                //ligth
                e.Graphics.FillRectangle(OnPen, (indent + 2), 2, this.Size.Width - (indent + 4), this.Size.Height - 4);
                //Toggle
                e.Graphics.DrawRectangle(ControlPen, this.Size.Width - (toggleblocsize + 1), -0, this.Size.Width - (indent + 1), this.Size.Height - 1);
                e.Graphics.FillRectangle(ToggleBrush, this.Size.Width - (toggleblocsize), -1, this.Size.Width, this.Size.Height + 1);
                if (ColorText && this.Enabled) TextBrush = new SolidBrush(OnColor);//_label.ForeColor = OnColor;
                // _label.Text = "On";
                // Draw string to screen.
                TextRenderer.DrawText(e.Graphics, OnText, this.Font, texttangle, TextBrush.Color, this.Parent.BackColor,
                                    TextFormatFlags.HorizontalCenter |
                                    TextFormatFlags.VerticalCenter |
                                    TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                //ligth
                e.Graphics.FillRectangle(OffPen, (indent + 2), 2, this.Size.Width - (indent + 4), this.Size.Height - 4);
                //Toggle
                e.Graphics.DrawRectangle(ControlPen, indent, -0, (toggleblocsize + 1), this.Size.Height - 1);
                e.Graphics.FillRectangle(ToggleBrush, (indent + 1), -1, (toggleblocsize), this.Size.Height + 1);
                if (ColorText && this.Enabled) TextBrush = new SolidBrush(SystemColors.ControlText);
                // Draw string to screen.
                TextRenderer.DrawText(e.Graphics, OffText, this.Font, texttangle, TextBrush.Color, this.Parent.BackColor,
                                TextFormatFlags.HorizontalCenter |
                                TextFormatFlags.VerticalCenter |
                                TextFormatFlags.GlyphOverhangPadding);
            }
