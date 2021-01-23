    var comboBox = new ComboBox();
    comboBox.DisplayMember = "Name";
    comboBox.Items.AddRange(FontFamily.Families);
    comboBox.DrawMode = DrawMode.OwnerDrawFixed;
    comboBox.DrawItem += (s, e) => {
        
        var fontFamily = (FontFamily) comboBox.Items[e.Index];
        var itemText = comboBox.GetItemText(fontFamily);
        
        // Some fonts don't work with a regular style, if they don't have a
        // regular style, we'll default to the provided font.
        if (!fontFamily.IsStyleAvailable(FontStyle.Regular))
        {
            TextRenderer.DrawText(
                e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, e.BackColor
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }
        else
        {
            using (var font = new Font(fontFamily, comboBox.Font.Size, FontStyle.Regular))
            {
                TextRenderer.DrawText(
                    e.Graphics, itemText, font, e.Bounds, e.ForeColor, e.BackColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }
    };
