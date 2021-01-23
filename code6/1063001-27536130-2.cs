    CheckBox imageCheckBox(Image img, Size size, string name)
    {
        CheckBox cbx = new CheckBox();
        cbx.AutoSize = false;
        cbx.Text = "";
        cbx.CheckAlign = ContentAlignment.TopLeft;
        cbx.BackgroundImageLayout = ImageLayout.Zoom;
        cbx.Size = size;
        cbx.BackgroundImage = img;
        cbx.Name = name,
        cbx.BackColor = SystemColors.Control;
        cbx.CheckedChanged += (s, e) =>
            {
                cbx.BackColor =
                cbx.Checked ? SystemColors.GradientActiveCaption : SystemColors.Control;
            };
        return cbx;
    }
