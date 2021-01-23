           lines.SelectionChanged += (o, e) =>
            {
                MessageBox.Show("clist   _SelectionChanged1");
                txtblk1ShowStatus.Text = lines.SelectedItem.ToString();
            };
            lines.SelectedIndex = lines.Items.Count - 1;
