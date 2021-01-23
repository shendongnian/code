        private void Select(object sender, RoutedEventArgs e)
        {
            if (currentindex != -1)
            {
                text.BeginChange();
                if (text.Selection.Text != string.Empty)
                {
                    text.Selection.Text = string.Empty;
                }
                var ch = new Run(((SymbolView) canvas.Children[currentindex]).charcter.Text)
                    {
                        FontFamily = fonts.SelectedItem as FontFamily
                    };
                text.CaretPosition.Paragraph.Inlines.Add(ch);
                text.EndChange();
                // Displays escaped char code
                MessageBox.Show(string.Format("&#x{0:X4}", (int) ch.Text[0])); 
            }
        }
