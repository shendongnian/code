        ObservableCollection<Item> allItems;
        private Item copiedItem;
        private void tableInput_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            //if row itself is copied as opposed to a number
            if(e.Item is Item)
                copiedItem=(Item)e.Item;
        }
        private void tableInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                //if row itself is copied
                if(copiedItem!=null) { 
                    if(dataGrid.CurrentItem != null)
                    {
                        for(int i=0;i<allItems.Count;i++)
                        {
                            if(allItems[i].Equals(dataGrid.CurrentItem))
                            {
                                allItems[i]=DeepClone<Item>(copiedItem);
                            }
                        }
                    }
                }
            }
        }
        [Serializable]
        public class Item
        {
            public string Name {get;set; }
            public string Max_Flow {get;set; }
        }
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
