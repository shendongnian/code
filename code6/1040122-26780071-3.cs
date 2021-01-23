                    color.MenuItems.Add(new MenuItem("#123456", menuHandler));
                    color.MenuItems.Add(new MenuItem("Green", menuHandler));
                    color.MenuItems.Add(new MenuItem("Red", menuHandler));
                    foreach (MenuItem item in color.MenuItems)
                    {
                        item.OwnerDraw = true;
                        item.DrawItem += item_DrawItem;
                        item.MeasureItem += MeasureMenuItem;
                    }
