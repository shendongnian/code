    [HttpGet]
    public ActionResult Create()
    {
        // We should check if one exists and reuse it instead, but omitted for clarity
        var context = new InputContext(GetUserId(), GetRouteName());
        db.Contexts.Add(context);
        db.Save(context);
        var model = new RecipeInput(context.Id);
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(RecipeInput model)
    {
        // Save the current input to DB
        db.RecipeInputs.Update(model);
        db.Save();
        // Do validation and return Create view on error...
        // load the context and related variations created
        var context = db.Contexts.Find(model.ContextId);
        var children = db.VariationInputs.Where(x => x.ContextId == context.Id).ToList();
        
        // Create the actual models from the input.
        var recipe = new Recipe();
        // set values from model
        
        foreach (var child in children )
        {
           var variation = new Variation();
           // set values from child
           recipe.Variations.Add(variation);
        }
        db.Recipes.Add(recipe);
        db.Save();
        // Cleanup if it worked
        db.RecipeInputs.Delete(model.Id);
        foreach (var child in children )
        {
           db.VariationInputs.Delete(child.Id);
        }
        // you could keep the Contexts as logs or delete them
        //...        
    }
