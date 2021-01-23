    var mergetool = new ThirdPartyToolDefinition(".*",ToolOperations.Merge,"vsDiffMerge.exe","","/m %1 %2 %3 %4");
    var toolcol= ThirdPartyToolDefinitionCollection.Instance.FindTool(".*",ToolOperations.Merge);
    if (toolcol == null)
       {
        ThirdPartyToolDefinitionCollection.Instance.AddTool(mergetool);
        ThirdPartyToolDefinitionCollection.Instance.PersistAllToRegistry();
       }
    var controlsAssembly = Assembly.GetAssembly(typeof(ControlAddItemsExclude));
    var vcResolveCoinflictsDialogType = controlsAssembly.GetType("Microsoft.TeamFoundation.VersionControl.Controls.DialogResolveConflicts");
    var ci = vcResolveCoinflictsDialogType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(Workspace), typeof(string[]), typeof(bool) }, null);
    var resolveCoinflictsDialog = (Form)ci.Invoke(new object[] { workspace, null, true });
    resolveCoinflictsDialog.ShowDialog(parent);
    ThirdPartyToolDefinitionCollection.Instance.Remove(mergetool);
    ThirdPartyToolDefinitionCollection.Instance.PersistAllToRegistry();
