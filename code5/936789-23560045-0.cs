        private new void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ((SomeVM)this.DataContext).EditSelectedItem();
            }
            else if (e.Key == Key.Delete && this.TreeView.SelectedItem != null &&
                this.TreeView.SelectedItem is DiffVM)
            {
                ((SomeVM)this.DataContext).DeleteDiffV();
            }
         }
