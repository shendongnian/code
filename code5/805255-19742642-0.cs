    foreach (GridViewColumn g in gvLists)
            {
                if (!grdView.Columns.Contains(g))
                {
                    g = new GridViewColumn();
                    grdView.Columns.Add(g);
                }
            }
