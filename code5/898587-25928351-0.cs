    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
      handled = false;
      if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
      {
        if (commandName == "ProxyClassCreatorAddin.Connect.ProxyClassCreatorAddin")
        {
          string filePath = string.Empty;
          UIHierarchy uih = _applicationObject.ToolWindows.SolutionExplorer;
          Array selectedItems = (Array)uih.SelectedItems;
          if (selectedItems != null)
          {
            foreach (UIHierarchyItem item in selectedItems)
            {
              var x = item.Object.GetType();
              Project projectItem = item.Object as Project;
              filePath = projectItem.Properties.Item("FullPath").Value.ToString();
            }
          }
            
          handled = true;
          CreateProxyClasses.CreateProxyClasses form = new CreateProxyClasses.CreateProxyClasses(filePath);
          form.ShowDialog();
        }
      }
    }
