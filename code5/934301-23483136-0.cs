	void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.NewItems != null && e.NewItems.Count != 0)
			foreach (WorkspaceViewModel workspace in e.NewItems)
			{
				if (tab.GetType() == typeof(Tab01ViewModel))
					workspace.RequestClose += this.OnWorkspaceRequestCloseTab01;
				
				if (tab.GetType() == typeof(Tab02ViewModel))
					workspace.RequestClose += this.OnWorkspaceRequestCloseTab02;
					
				if (tab.GetType() == typeof(Tab03ViewModel))
					workspace.RequestClose += this.OnWorkspaceRequestCloseTab03;
				
				// and so on ...
			}
			
		if (e.OldItems != null && e.OldItems.Count != 0)
			foreach (WorkspaceViewModel workspace in e.OldItems)
			{
				if (tab.GetType() == typeof(Tab01ViewModel))
					workspace.RequestClose -= this.OnWorkspaceRequestCloseTab01;
				
				if (tab.GetType() == typeof(Tab02ViewModel))
					workspace.RequestClose -= this.OnWorkspaceRequestCloseTab02;
					
				if (tab.GetType() == typeof(Tab03ViewModel))
					workspace.RequestClose -= this.OnWorkspaceRequestCloseTab03;
				
				// and so on ...
			}
	}
	
	
	/// <summary>
	/// Closes and removes a tab of type Tab01ViewModel
	/// </summary>
	void OnWorkspaceRequestCloseTab01(object sender, EventArgs e)
	{
		WorkspaceViewModel workspace = sender as WorkspaceViewModel;
		
		 if(Tab01ViewModel.IsContentOfTextboxesChanged) 
		{
			var result = System.Windows.Forms.MessageBox.Show(
				"Changes to the tab-content »" + Tab01ViewModel.TabTitle +
				"« were made, without setting them." + 
				"\n\nHint: If closing, any content changes will be lost!" + 
				"\n\nDo you really want to close this tab?",
				"MessageboxTitle", MessageBoxButtons.OKCancel, 
				MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				workspace.Dispose();
				this.Workspaces.Remove(workspace);
			}
		}
		else 
		{
			workspace.Dispose();
			this.Workspaces.Remove(workspace);
		}
	}
	
	
	/// <summary>
	/// Closes and removes a tab of type Tab02ViewModel
	/// </summary>
	void OnWorkspaceRequestCloseTab02(object sender, EventArgs e)
	{
		WorkspaceViewModel workspace = sender as WorkspaceViewModel;
		
		 if(Tab02ViewModel.IsContentOfTextboxesChanged) 
		{
			var result = System.Windows.Forms.MessageBox.Show(
				"Changes to the tab-content »" + Tab02ViewModel.TabTitle +
				"« were made, without setting them." + 
				"\n\nHint: If closing, any content changes will be lost!" + 
				"\n\nDo you really want to close this tab?",
				"MessageboxTitle", MessageBoxButtons.OKCancel, 
				MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				workspace.Dispose();
				this.Workspaces.Remove(workspace);
			}
		}
		else 
		{
			workspace.Dispose();
			this.Workspaces.Remove(workspace);
		}
	}
	
	
	/// <summary>
	/// Closes and removes a tab of type Tab03ViewModel
	/// </summary>
	void OnWorkspaceRequestCloseTab03(object sender, EventArgs e)
	{
		WorkspaceViewModel workspace = sender as WorkspaceViewModel;
		
		 if(Tab03ViewModel.IsContentOfTextboxesChanged) 
		{
			var result = System.Windows.Forms.MessageBox.Show(
				"Changes to the tab-content »" + Tab03ViewModel.TabTitle +
				"« were made, without setting them." + 
				"\n\nHint: If closing, any content changes will be lost!" + 
				"\n\nDo you really want to close this tab?",
				"MessageboxTitle", MessageBoxButtons.OKCancel, 
				MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				workspace.Dispose();
				this.Workspaces.Remove(workspace);
			}
		}
		else 
		{
			workspace.Dispose();
			this.Workspaces.Remove(workspace);
		}
	}
