    ObservableCollection<int> cA = new ObservableCollection<int>();
    ObservableCollection<int> cB = new ObservableCollection<int>();
    
    cA.CollectionChanged += (sender, ev) =>
    {
        switch (ev.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (int i in ev.NewItems)
                {
                    Console.WriteLine("Item added");
                    cB.Add(i);
                }
                break;
            case NotifyCollectionChangedAction.Replace:
                var idx = ev.NewStartingIndex;
                var value = (int)ev.NewItems[0];
                Console.WriteLine("Item {0} replaced with {1}", idx, value);
                cB[idx] = value;
                break;
        }
    };
    
    cA.Add(1);
    cA.Add(2);
    cA[1] = 3;
    
    Console.WriteLine(cB[1]); // outputs 3
