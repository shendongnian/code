    private void AddSections<T>(
        IEnumerable<CardViewModel> cards,
        StringBuilder builder,
        Func<CardViewModel, T> order,
        Func<CardViewModel, T, bool> prepredicate)
    {
        cards = cards.OrderBy(order);
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            Func<CardViewModel, bool> predicate = f => prepredicate(f,value);
            ...
    AddSections<CardTypes>(cards, builder, order, (f,t) => f.CardType == t);
