        var recipes = new List<Recipe>(){
                new Recipe(){
                        Name = "Wood Sword",
                        RecipeItems = new List<RecipeItem>(){
                                new RecipeItem(){
                                        Ingredient = Wood,
                                        Amount = 1
                                },
                                new RecipeItem(){
                                        Ingredient = Stone,
                                        Amount = 5
                                }
                        }
                },
                new Recipe(){
                        Name = "Plank",
                        RecipeItems = new List<RecipeItem>(){
                                new RecipeItem(){
                                        Ingredient = Wood,
                                        Amount = 5
                                }
                        }
                }
                // More recipes
        };
