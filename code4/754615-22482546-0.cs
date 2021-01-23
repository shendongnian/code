	private string ReadableDataGridViewContext(DataGridViewDataErrorContexts context)
	{
		var translations = new Dictionary<DataGridViewDataErrorContexts, string> {
			{ DataGridViewDataErrorContexts.ClipboardContent, "Copying Data to the Clipboard" },
			{ DataGridViewDataErrorContexts.Commit, "Committing Data" },
			{ DataGridViewDataErrorContexts.CurrentCellChange, "Moving Focus to a different Cell, due to error in the Cell being left" },
			{ DataGridViewDataErrorContexts.Display, "Displaying Data in a Cell" },
			{ DataGridViewDataErrorContexts.Formatting, "Formatting Data" },
			{ DataGridViewDataErrorContexts.InitialValueRestoration, "Restoring Cell Data" },
			{ DataGridViewDataErrorContexts.LeaveControl, "Leaving the Grid" },
			{ DataGridViewDataErrorContexts.Parsing, "Parsing Data" },
			{ DataGridViewDataErrorContexts.PreferredSize, "Calculating the preferred size for a Cell" },
			{ DataGridViewDataErrorContexts.RowDeletion, "Deleting a Row" },
			{ DataGridViewDataErrorContexts.Scroll, "Scrolling over the Grid" }
		};
		var list = (from contextFlag in translations.Keys
						where context.HasFlag(contextFlag)
						select translations[contextFlag]).ToList();
		return String.Join(",", list);
	}
