                    color.MenuItems.Add(new MenuItem("#123456", setcolouryellow));
                    color.MenuItems.Add(new MenuItem("Green", setcolourgreen));
                    color.MenuItems.Add(new MenuItem("Red", setcolourred));
                    foreach (MenuItem item in color.MenuItems)
                    {
                        item.OwnerDraw = true;
                        item.DrawItem += item_DrawItem;
                        item.MeasureItem += MeasureMenuItem;
                    }
