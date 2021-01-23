    public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams) 
    {
	    //Adding by template is unavailable in the context menu when selecting more than one item -> use index 0. 
     	UIHierarchyItem selectedUiHierarchyItem = (UIHierarchyItem )dte.ToolWindows.SolutionExplorer.SelectedItems[0]; 
	    //not null when selecting solution node (when adding a project)
	    Solution selectedSolution = selectedUiHierarchyItem.Object as Solution 
	
	    //not null when selecting project node (when adding an item) or when selecting a solution folder (when adding a project)
	    Project selectedProject = selectedUiHierarchyItem.Object as Project;
	    //Determine which kind of project node: 
	    if (selectedProject != null)
	    {
			if (selectedProject.Kind == EnvDTE.Constants.vsProjectKindSolutionItems)
			{
				//solution folder
			}
			else
			{
				//project
	     		replacementsDictionary.Add("$projectname$", selectedProject.Name);
			}
	    }
    }
