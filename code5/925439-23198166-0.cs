    private void AddSections<T>(
		IEnumerable<CardViewModel> cards,
		StringBuilder builder,
		Func<CardViewModel, T> order,
		Func<T, Func<CardViewModel, bool>> predicateFactory)
    {
        cards = cards.OrderBy(order);
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            if (!cards.Any(predicateFactory(value)))
                continue;
            builder.Append(value.ToString() + ": ");
            builder.Append(cards
                .Where(predicateFactory(value))
                .Sum(f => f.AmountInDeck));
            builder.Append(Environment.NewLine);
            foreach (CardViewModel card in cards.Where(predicateFactory(value)))
            {
                builder.Append(card.AmountInDeck.ToString()
					+ "\t"
					+ card.Name.Name
					+ Environment.NewLine);
            }
            builder.Append(Environment.NewLine);
        }
    }
