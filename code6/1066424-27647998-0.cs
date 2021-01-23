    class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    var collection = new ObservableCollection<Entity>
    {
        new Entity { Id = 1, Name = "Apple" },
        new Entity { Id = 2, Name = "Peach" },
        new Entity { Id = 3, Name = "Plum" },
        new Entity { Id = 4, Name = "Grape" },
        new Entity { Id = 5, Name = "Orange" },
    };
    collection.CollectionChanged += (sender, args) =>
    {
        if (args.Action == NotifyCollectionChangedAction.Remove || args.Action == NotifyCollectionChangedAction.Replace)
        {
            for (var i = args.OldStartingIndex; i < collection.Count; i++)
            {
                collection[i].Id--;
            }
        }
    };
    
    collection.RemoveAt(2); // Grape.Id == 3, Orange.Id == 4
