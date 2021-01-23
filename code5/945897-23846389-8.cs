    private void pictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        var text = !String.IsNullOrEmpty(textBox.Text) ? textBox.Text : "copyright 2014";
        var imageCoordinates = translateStretchImageMousePosition(new Point(e.X, e.Y));
        using (var graphics = Graphics.FromImage(pictureBox.Image))
        {
            var font = new Font(FontFamily.GenericSansSerif, 16.0f);
            graphics.DrawString(text, font, Brushes.Red, imageCoordinates);
        }
        pictureBox.Refresh();
    }
