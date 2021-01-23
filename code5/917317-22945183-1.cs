    public void ProcessCardSwipe(CardData cardData)
    {
        var cardInfo = new CreditCardPaymentInfo { CardInfo = cardData };
        ProcessPaymetnInfo(cardInfo);
    }
    public void ProcessPaymetnInfo(IPaymentInfo paymentInfo)
    {
        // This should be refactored into a separate class, but initially to get it working this is fine
        if (paymentInfo is CreditCardPaymentInfo)
        {
            new CreditCardPaymentProcessor().Process((paymentInfo)CreditCardPaymentInfo);
        }
    }
