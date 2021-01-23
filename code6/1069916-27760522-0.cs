    private void onRefreshMenuClick(object sender, RoutedEventArgs e)
    {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                ContextMenu cm = mi.CommandParameter as ContextMenu;
                if (cm != null)
                {
                    Grid g = cm.PlacementTarget as Grid;
                    if (g != null)
                    {
                        // need something here like g.getrowof(cm.placementtarget)
                        var point = Mouse.GetPosition(g);
                        int row = 0;
                        int col = 0;
                        double accumulatedHeight = 0.0;
                        double accumulatedWidth = 0.0;
                        // calc row mouse was over
                        foreach (var rowDefinition in g.RowDefinitions)
                        {
                            accumulatedHeight += rowDefinition.ActualHeight;
                            if (accumulatedHeight >= point.Y)
                                break;
                            row++;
                        }
                        // calc col mouse was over
                        foreach (var columnDefinition in g.ColumnDefinitions)
                        {
                            accumulatedWidth += columnDefinition.ActualWidth;
                            if (accumulatedWidth >= point.X)
                                break;
                            col++;
                        }
                    } 
                }
            }   
     }
