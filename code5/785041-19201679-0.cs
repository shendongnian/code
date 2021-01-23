    class MainDeck : List<Card>
    {
       public MainDeck()
        {
            this.Add(new Card(1, "Hearts"));
            this.Add(new Card(2, "Hearts"));
            this.Add(new Card(3, "Hearts"));
            ...
    
            this = this.OrderBy(a => Guid.NewGuid());
        }
    }
