		List<Process> pOriginalList = null;
		pOriginalList = Processes.ToList();
		private void OnDeletePressed(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Delete)
			{
				foreach (Process item in ProcessListBox.SelectedItems.OfType<Process>().ToList())
				{
					this.Processes.Remove(item);
				}
			}
		}
		private void OnSaveClick(object sender, RoutedEventArgs e)
		{
			// do nothing -- Processes already is set
		}
		private void OnCancelClick(object sender, RoutedEventArgs e)
		{
			Processes.Clear();
			Processes = new ObservableCollection<Process>(pOriginalList);
			this.DataContext = null;
			this.DataContext = this;
		}
