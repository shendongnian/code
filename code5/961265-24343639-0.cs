		private void resizeDataGridRowHeight() {
			int a = boundDataGrid.Items.Count;
			int calibrationRowHeight = 28;
			for (int i = 0; i < a; i++) {
				myRowHeight = ListofObjectsThatEachRepresentAParameter.ListOfDataTableRows[i].ListOfCalibrationRows.Count * calibrationRowHeight;
				DataGridRow row = boundDataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
				row = boundDataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
				row.Height = myRowHeight;
			}
		}
