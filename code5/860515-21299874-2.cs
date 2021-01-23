    var session = ...// get a ISession 
    Reciepe reciepe = null; // this will be a reference to parent
    // the SELECT inside of EXISTS
    var subquery = QueryOver.Of<ReciepeIngredient>()
        // The PARENT handling here
        // the filter, to find only related ingredients
        .Where(item => item.ReciepeId == reciepe.ID)
        .Where(Restrictions.In("ID", new[] { 5, 10, 15 }))
        // Select clause
        .Select(ing => ing.ID)
                
        ;
