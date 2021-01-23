        private void Txt_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var txtBox = e.Source as TextBox;
                var selectionStart = txtBox.SelectionStart;
                txtBox.Text = txtBox.Text.Insert(selectionStart, "\n");
                txtBox.Select(selectionStart + 1, 0);
                e.Handled = true;  
            }
        }
