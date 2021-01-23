    CheckBox imageCheckBox(Image img, Size size, string name)
    {
        CheckBox cbx = new CheckBox();
        cbx.AutoSize = false;
        cbx.Text = "";
        cbx.CheckAlign = ContentAlignment.TopLeft;
        cbx.BackgroundImageLayout = ImageLayout.Zoom;
        cbx.Size = size;
        cbx.BackgroundImage = img;
        cbx.Name = name;
        cbx.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
        cbx.BackColor = SystemColors.Control;
        cbx.CheckedChanged += (s, e) =>
        {
            cbx.BackColor = cbx.Checked ? SystemColors.Control : SystemColors.Window;
        };
        cbx.MouseEnter += (s, e) =>
        {
            cbx.BackColor = cbx.Checked ? SystemColors.GradientActiveCaption :      
                                          SystemColors.GradientInactiveCaption;
        };
        cbx.MouseLeave += (s, e) =>
        {
            cbx.BackColor = cbx.Checked ? SystemColors.Control : SystemColors.Window;
        };
        cbx.Paint += (s, e) =>
        {
            if (cbx.ClientRectangle.Contains(cbx.PointToClient(Cursor.Position))  
            ||  cbx.Checked))
            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, cbx.Width - 1, cbx.Height - 1);
        };
        return cbx;
    }
