    public void AddCard(Customer customer, Card card)
    {
        if (customer.Card != null)
        {
            context.Cards.Remove(customer.Card);
        }
        customer.Card = card;
    }
