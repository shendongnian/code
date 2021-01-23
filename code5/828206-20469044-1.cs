        private readonly ListViewItem _blankListItem = new ListViewItem();
        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (!listView.ItemIsVisible(e.ItemIndex))
            {
                e.Item = _blankListItem;
                return;
            }
            var anItem = _listViewItems[e.ItemIndex];
            if (anItem == null)
            {
                anItem = CreateListItemFromElement(_source.GetData(e.ItemIndex));
                _listViewItems[e.ItemIndex] = anItem;
            }
            e.Item = anItem;
        }
