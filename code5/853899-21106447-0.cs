    EnvDTE.UIHierarchy solutionExplorer = dte.ToolWindows.SolutionExplorer;
    object[] items = solutionExplorer.SelectedItems as object[];
    EnvDTE.UIHierarchyItem item = items[0] as EnvDTE.UIHierarchyItem;
    EnvDTE.ProjectItem projectItem = item.Object as EnvDTE.ProjectItem;
    string path = projectItem.Properties.Item("FullPath").Value.ToString();
