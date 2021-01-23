                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems[m.MenuItems.Count - 1].OwnerDraw = true;
                    m.MenuItems[m.MenuItems.Count - 1].DrawItem += Cm_DrawItem;
                    m.MenuItems.Add(new MenuItem(string.Format("Row number {0}", currentMouseOverRow.ToString())));
                    //m.MenuItems[m.MenuItems.Count -1].Enabled = false;
                }
