    public class MyData
    {
        // Properties, etc...
        public Task Save()
        {
            // Asynchronously saves to database, throws exception on error
        }
    }
	void MyGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
	{
		if (e.EditAction == DataGridEditAction.Commit)
		{
			var item = (MyData)e.Row.Item;
			try
			{
                // Force the awaitable task to complete synchronously
                // Have to use Task.Run to keep the awaited task from deadlocking
                var task = Task.Run(async () => { await item.Save(); });
                task.Wait();
			}
			catch (Exception ex)
			{
                // We get here on an exception thrown from Save
                MessageBox.Show(ex.Message);
				
                e.Cancel = true; // <== Can do this just as before
			}
		}
	}
