    var cards = db.Cards.Select(c => 
                    new {
                        CardNumber = c.CardNumber,
                        Name = c.Member.Name,
                        Date = c.Member.Date
                    }
                ).ToList();
    foreach (var card in cards)
    {
        int cardNumber = card.CardNumber;
        string name = card.Name;
        DateTime date = card.Date;
    }
