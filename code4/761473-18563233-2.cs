        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {  
            Brush brush;
            var g = e.Graphics;
            var rect = e.Bounds;
            var n = "";
            var f = new Font("Arial", 9, FontStyle.Regular);
            switch (((ComboBoxValue)((ComboBox)sender).SelectedItem).Status)
            {
                case "one":
                    brush = Brushes.Red;
                    break;
                case "two":
                    brush = Brushes.Green;
                    break;
                default:
                    brush = Brushes.White;
                    break;
            }
            if (e.Index >= 0)
            {
                n = ((ComboBoxValue)((ComboBox)sender).SelectedItem).Name;
            }
            g.FillRectangle(brush, rect.X, rect.Y,rect.Width, rect.Height);
            g.DrawString(n, f, Brushes.Black, rect.X, rect.Y);
        }
