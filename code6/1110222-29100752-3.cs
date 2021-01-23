    private void InternalUpdate(int id, double percentagem, string status)
    {
        this.Dispatcher.Invoke(() =>
        {
            var item = EncodingListBox.Items.Cast<EncoderListViewItem>().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Percentage = percentagem;
                item.Text = status;
            }
         });
    }
