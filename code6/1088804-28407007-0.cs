    private void SearchT_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (SearchT.Text != "")
            {
                for (int i = ListWord.Items.Count - 1; i >= 0; i--)
                {
                    var item = ListWord.Items[i];
                    if (item.ToString().Contains(SearchT.Text.ToString()))
                    {
                        ListWord.ScrollIntoView(item);
                        break;
                    }
                }
            }
        }
