    public bool IsCardCodeDuplicate(long? organizationId, string cardNumber)
    {
        IList<CardDto> card = CardData.Instance.GetCardList(organizationId, null);
        return card.Any(p => p.CardNumber == cardNumber);       
    }
