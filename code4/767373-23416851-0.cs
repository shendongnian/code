    private void Button1_Paint(object sender, PaintEventArgs e)
            {
                Button btn = (Button)sender;
                // make sure Text is not also written on button
                btn.Text = string.Empty;
                // set flags to center text on button
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;   // center the text
                // render the text onto the button
                TextRenderer.DrawText(e.Graphics, "Hello", btn.Font, e.ClipRectangle, btn.ForeColor, flags);
            }
