        private void SetSelectedItems()
        {
            var selectedItems = new Dictionary<string, object>();
            foreach (Node node in _nodeList)
            {
                if (node.IsSelected && node.Title != "All")
                {
                    if (this.ItemsSource.Count > 0)
 
                        selectedItems.Add(node.Title, this.ItemsSource[node.Title]);
                }
            }
            // this should now result in a call to the SelectedTargetGroups setter you have
            SelectedItems = selectedItems;
        }
