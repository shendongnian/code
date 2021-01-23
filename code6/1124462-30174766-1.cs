     /// <summary>
     /// Sends mouse events from the overlaying grid to the PlotView. Forcing an Action.
     /// This was included due to an OxyPlot bug where the OnMouse... methods were not being called 
     /// when the plot was invalidated via InvalidatePlot(...)
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     private void Grid_MouseCatcher_MouseDown(object sender, MouseButtonEventArgs e)
     {
         Debug.WriteLine("MouseCatcher - Down: " + e.GetPosition(Grid_MouseCatcher).X + " " + e.GetPosition(Grid_MouseCatcher).Y);
         PlotView.ForceMouseDown(e);
     }
