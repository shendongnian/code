        private static void OnSelectedItemChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs e)
        {
           if (e.AddedItems != null && e.AddedItems.Count > 0)
           {
              ((YourViewModel)this.DataContext).NewSelectedItemMethodOrWhateverYouWant(e.AddedItems.FirstOrDefault())
           }
        }
