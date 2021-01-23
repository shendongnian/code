     RadPaneGroup container = App.Current.MainWindow.FindName(ContentContainerName) as RadPaneGroup;
    foreach (RadPane pane in container.Items)
     {
      if (pane.IsActive)
      {
        pane.RemoveFromParent();
        break;
      }
     }
 
