    // Animals property setter must raise "property changed" event to notify binding clients.
    // See INotifyPropertyChanged interface for details.
    Animals = new ObservableCollection<string>
        {
            "Cat", "Dog", "Bear", "Lion", "Mouse",
            "Horse", "Rat", "Elephant", "Kangaroo",
            "Lizard", "Snake", "Frog", "Fish",
            "Butterfly", "Human", "Cow", "Bumble Bee"
        };
    ...
    Animals = new ObservableCollection<string>(Animals.OrderBy(i => i));
