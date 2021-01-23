    (Recipe recipe in recipes)
                    {
                        if (recipe.All(i =>
                        {
                            // this
                            Item item = inventory.Inventory.FirstOrDefault(x => x != null && x.ID == i.ID);
                            return (item == null) ? false : (item.Amount >= i.Amount);
                        }))
                            ableToCraft.Add(recipe);
                    }
