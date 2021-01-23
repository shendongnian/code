    var context = new MyDomainContext();
    context.UpdateCol3OfAllEntities(operation => 
        {
            if (operation.HasError)
            {
                // If in trouble or in doubt, run in circles, scream and shout!
                operation.MarkErrorAsHandled();
            }
            else
            {
                // Rejoice, for the operation succeeded!
            }
        }, null);
