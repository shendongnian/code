    public void Exec(
      string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
      handled = false;
      if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
      {
        if (commandName == "ProxyClassCreatorAddin2.Connect.ProxyClassCreatorAddin2")
        {
          string filePath = string.Empty;
          var selectedItems = (Array)_applicationObject.ToolWindows.SolutionExplorer.SelectedItems;
          if (selectedItems != null)
          {
            foreach (UIHierarchyItem item in selectedItems)
            {
              ------------------------------------------------
              dynamic obj = item.Object;
              filePath = obj.Path;
              -------------------------------------------------
            }
          }
          handled = true;
          MessageBox.Show(filePath);
          CreateProxyClasses.CreateProxyClasses form = new CreateProxyClasses.CreateProxyClasses(filePath);
          form.Show();
          return;
        }
      }
    }
