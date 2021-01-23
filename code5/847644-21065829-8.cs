    internal void RemoveItem(object item)
        {
            var itemIndex = this.Items.IndexOf(item);
            if (itemIndex > 0)
            {
                SelectedItem = Items[itemIndex - 1];
            }
            else if (Items.Count > 1)
            {
                SelectedItem = Items[itemIndex + 1];
            }
            this.Items.Remove(item);
        }
