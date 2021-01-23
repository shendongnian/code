        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = GetSelectedIndexFromList();
        }
        private int GetSelectedIndexFromList()
        {
            var container = myListBox.ItemContainerGenerator.ContainerFromItem(MyListBox.SelectedItem);
            var index = myListBox.ItemContainerGenerator.IndexFromContainer(container);
            return index;
        }
      
