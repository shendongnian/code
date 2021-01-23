            Items = new ObservableCollection<Item>();
            Items.Add(new Item() { Key = "abcd", Data = 1 });
            Items.Add(new Item() { Key = "abcd", Data = 2 });
            Items.Add(new Item() { Key = "qwer", Data = 1 });
            Items.Add(new Item() { Key = "qwer", Data = 2 });
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Items);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Key");
            view.GroupDescriptions.Add(groupDescription);
