    private SequenceCollection = new ObservableCollection<Sequence>();
    Random random = new Random();
    
    public void UpdateBeat()
    {
        int randomNumber = random.Next(0, 100);
    
        SequenceCollection.Add(new Sequence(1, 2));            
    }
