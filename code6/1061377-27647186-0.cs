    //Update food in total graph depth <= 2.
    db.UpdateGraph(food, map => map.AssociatedCollection(f => f.FoodVarieties));
    
    //.... (Other UpdateGraph calls with graph depth <=2)
    //Update recipe steps of recipe in total graph depth <= 2.
    foreach (RecipeStep recipeStep in food.FoodRecipe.RecipeSteps)
    {
    	recipeStep.ActionOfUser = db.UserActions.FirstOrDefault(ua => ua.EntityID == recipeStep.ActionOfUser.EntityID);
        //If you have to do an inner node adding operation in the graph, do it manually.
    	if (recipeStep.EntityID == 0)
    	{
    		recipeStep.BelongingRecipe = db.Recipes.FirstOrDefault(r => r.EntityID == food.FoodRecipe.EntityID);
    		db.RecipeSteps.Add(recipeStep);
    	}
    	else
    	{
    		//Map slots & recipeSteps applied manually here.
    		recipeStep.StartObjectSlots.ForEach(sos => sos.BelongingRecipeStepAsStart = recipeStep);
    		recipeStep.EndObjectSlots.ForEach(eos => eos.BelongingRecipeStepAsEnd = recipeStep);
    
    		db.UpdateGraph(recipeStep, map => map.OwnedCollection(rs => rs.InteractiveObjectInstancesLists, withIOILists => withIOILists.
    			    OwnedCollection(ioil => ioil.InteractiveObjectsInstances)
    		    ).
    		    OwnedCollection(rs => rs.StartObjectSlots, withStartObjectSlots => withStartObjectSlots.
    			    AssociatedEntity(sos => sos.BelongingRecipeStepAsStart)
    		    ).
    		    OwnedCollection(rs => rs.EndObjectSlots, withEndObjectSlots => withEndObjectSlots.
    		 	    AssociatedEntity(eos => eos.BelongingRecipeStepAsEnd)
    		    ).
    		    AssociatedEntity(rs => rs.ActionOfUser)
    	    );
    
    	}
    }
