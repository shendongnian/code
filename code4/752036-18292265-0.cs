    class Adventurer : IPerson { }
    class NPC : IPerson { }
    public void MyMethod(ObservableCollection<IPerson> collection)
    {
        collection.Add(new NPC());
    }
    var collectionOfAdventurers = new ObservableCollection<Adventurer>();
    MyMethod(collectionOfAdventurers);
