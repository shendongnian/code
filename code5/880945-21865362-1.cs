        private bool AddListViewItem(string item, string price, string noi)
        {
            if (this.DetectDuplicate(item, price, noi))
                return false;
            string[] content = new string[] { item, price, noi };
            ListViewItem newItem = new ListViewItem();
            newItem.Content = content;
            _listView.Items.Add(newItem);
            return true;
        }
        private bool DetectDuplicate(string item, string price, string noi)
        {
            foreach (ListViewItem lvwItem in _listView.Items)
            {
                string[] itemContent = lvwItem.Content as string[];
                Debug.Assert(itemContent != null);
                if (itemContent[0].Equals(item) &&
                    itemContent[1].Equals(price) &&
                    itemContent[2].Equals(noi))
                    return true;
            }
            return false;
        }
