    private void AddSections<T>(
		IEnumerable<CardViewModel> cards,
		StringBuilder builder,
		Func<CardViewModel, T> order)
    {
        cards = cards.OrderBy(order);
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            if (!cards.Any(c => order(c) == value))
                continue;
            builder.Append(value.ToString() + ": ");
            builder.Append(cards
				.Where(c => order(c) == value)
				.Sum(f => f.AmountInDeck));
            builder.Append(Environment.NewLine);
            foreach (CardViewModel card in cards.Where(c => order(c) == value))
            {
                builder.Append(card.AmountInDeck.ToString()
					+ "\t"
					+ card.Name.Name
					+ Environment.NewLine);
            }
            builder.Append(Environment.NewLine);
        }
    }
