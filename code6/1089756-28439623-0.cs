    var recipe = new Recipe();
    recipe.Ingredients.Add(myIngredient); // <-- this will be stored in a 
                                          //     new List<Ingredient>, 
                                          //     but not on the 
                                          //     _ingredients backing field
                                          //     since the get accesor doesn't 
                                          //     set it
    recipe.Ingredients.Add(myIngredient); // <-- this will be stored in a 
                                          //     new List<Ingredient>, not in 
                                          //     the expected created one
          
