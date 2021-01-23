        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox.Measure(new Size(Double.MaxValue, Double.MaxValue));
            var width = textBox.DesiredSize.Width;
            if (textBox.ActualWidth < width)
            {
                ToolTipService.SetToolTip(textBox, textBox.Text);
            }
            else
            {
                ToolTipService.SetToolTip(textBox, null);
            }
        }
