    public CardViewModel(Card card, SybaseDatabaseContext myDB)
    {
        this.Card = card;
    
        var query = from d in myDB.Departments
                    select d;
        this.Departments = new ObservableCollection<Department>(query);
    }
