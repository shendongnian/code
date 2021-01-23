    foreach (var action in trello.Actions.AutoPaged().ForBoard(board, 
        new[] { ActionType.CreateCard }).OfType<CreateCardAction>())
    {
        Console.WriteLine(action.Date + " - " + action.Data.Card.Name);
    }
