    private void flipView_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            if (flipView != null)
            {
                var item = flipView.SelectedItem as MyObj;
                string question = item.Question;
                string answer = item.Answer;
            }
        }
