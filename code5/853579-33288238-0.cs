    //+		_applicationObject.GetObject("Microsoft.VisualStudio.TeamFoundation.TeamFoundationServerExt")	{Microsoft.VisualStudio.TeamFoundation.TeamFoundationServerExt}	dynamic {Microsoft.VisualStudio.TeamFoundation.TeamFoundationServerExt}
    var tfsExt = (TeamFoundationServerExt)_applicationObject.GetObject("Microsoft.VisualStudio.TeamFoundation.TeamFoundationServerExt");
    //if ((tfsExt == null) || (tfsExt.ActiveProjectContext == null) || (tfsExt.ActiveProjectContext.DomainUri == null) || (tfsExt.ActiveProjectContext.ProjectUri == null)) { MessageBox.Show("Please Connect to TFS first and select a Team Project"); }
    //else { MessageBox.Show("Connected to:" + tfsExt.ActiveProjectContext.ProjectName); }
    var vsExt = _applicationObject.GetObject("Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt") as VersionControlExt;
    //vcs = vsExt.Explorer.Workspace.VersionControlServer;
    vcs = vsExt.SolutionWorkspace.VersionControlServer;
    vcs.OperationStarting += new OperationEventHandler(this.OperationHandler);
    vcs.UndonePendingChange += new PendingChangeEventHandler(this.UndoChange);
    vcs.Getting += new GettingEventHandler(this.GetHandler);
    vcs.NewPendingChange += new PendingChangeEventHandler(this.NewPendingChange);
    vcs.BeforeCheckinPendingChange += new ProcessingChangeEventHandler(this.BeforeCheckinPendingChange);
    vcs.CommitCheckin += new CommitCheckinEventHandler(this.CommitCheckin);
    vcs.Conflict += new ConflictEventHandler(this.Conflict);
    vcs.Merging += new MergeEventHandler(this.Merging);
    vcs.AfterWorkItemsUpdated += new AfterWorkItemsUpdatedEventHandler(this.AfterWorkItemsUpdated);
    vcs.BeforeWorkItemsUpdate += new BeforeWorkItemsUpdateEventHandler(this.BeforeWorkItemsUpdate);
    vcs.OperationFinished += new OperationEventHandler(this.OperationFinished);
    vcs.UpdatedWorkspace += new WorkspaceEventHandler(this.UpdatedWorkspace);
    vcs.WorkItemUpdated += new WorkItemUpdatedEventHandler(this.WorkItemUpdated);
