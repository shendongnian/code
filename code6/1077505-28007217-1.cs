    public void AddCard(Customer customer, Card card, Context context)
    {
        if (customer.Card != null)
        {
            context.Cards.Remove(customer.Card);
        }
        customer.Card = card;
    }
