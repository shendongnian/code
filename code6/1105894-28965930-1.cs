    //Old
    public CardModel AddCard(CardModel model, string username)
    {
        var user = context.users.Where(x => x.email.ToLower() == username.ToLower()).First();
        var card = new cards()
        {
            created = DateTime.Now,
            modified = DateTime.Now,
            name = model.Name,
            type = model.CardType,
            user_id = user.id
        };
        context.cards.Add(card);
        context.SaveChanges();
        model.Id = card.id;
        return model;
    }
    //New
    public CardModel AddCard(CardModel model, string username)
    {
        var user = context.users.Where(x => x.email.ToLower() == username.ToLower()).First();
        user.Cards.Add(model)
        user.SaveOrUpdate()
        return model;
    }
