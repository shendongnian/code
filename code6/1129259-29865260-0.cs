    // Nombre de lignes maximal (16 lignes à 1080p)
             int maxCharCount = (int)Window.Current.Bounds.Height * 16 / 1080;
    
             spIngredients.Children.Clear();
             foreach (var groupIngredient in db.Table<GroupIngredient>().Where(x => x.RecipeId == _currentRecipe.Id))
             {
                int linesCount = 0;
                int row = 0;
                var gGroup = new Grid();
                spIngredients.Children.Add(gGroup);
                gGroup.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
    
                var groupName = new TextBlock() { Text = groupIngredient.Name, FontSize = 20, FontWeight = FontWeights.SemiBold, Margin = new Thickness(10) };
                gGroup.Children.Add(groupName);
                Grid.SetRow(groupName, row);
    
                foreach (var ingredient in db.Table<Ingredient>().Where(x => x.GroupIngredientId == groupIngredient.Id))
                {
                   // Nombre de lignes, split à 45 char
                   linesCount += 1 + ingredient.IngredientFull.Length / 45;
    
                   if (linesCount >= maxCharCount)
                   {
                      var gCol = new Grid();
                      spIngredients.Children.Add(gCol);
                      gCol.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                      var col = new TextBlock() { Text = "", FontSize = 20, FontWeight = FontWeights.SemiBold, Margin = new Thickness(10) };
                      gCol.Children.Add(col);
                      gGroup = gCol;
    
                      row = 0;
                      linesCount = 0;
                      Grid.SetRow(col, row);
                   }
    
                   row++;
                   ingredient.Quantity = ingredient.Quantity * multiplier;
    
                   gGroup.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
    
                   var ingredientName = new TextBlock() { Text = ingredient.IngredientFull, Margin = new Thickness(10), FontSize = 18, TextWrapping = TextWrapping.Wrap, MaxWidth = 300 };
                   gGroup.Children.Add(ingredientName);
                   Grid.SetRow(ingredientName, row);
                }
             }
