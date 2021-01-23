       void MeasureMenuItem(object sender, MeasureItemEventArgs e)
            {
                MenuItem m = (MenuItem)sender;
                Font font = new Font(Font.FontFamily, Font.Size, Font.Style);
                SizeF sze = e.Graphics.MeasureString(m.Text, font);
                e.ItemHeight = (int)sze.Height;
                e.ItemWidth = (int)sze.Width;
            }
