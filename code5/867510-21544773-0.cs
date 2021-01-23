       private void somefunction()
    {
        Int32 id = Convert.ToInt32(((TextBlock)dataGrid1.Columns[0].GetCellContent(dataGrid1.SelectedItem)).Text.ToString());
        Service1Client obj = new Service1Client();
		obj.DeletePersonAsyncCompleted += new EventHandler<DeletePersonCompletedEventArgs>(PersonDeleted);
		
        obj.DeletePersonAsync(id);
    }
       
		
		private void PersonDeleted(DeletePersonCompletedEventArgs serviceResponse)
		{
		 //Wait for delete operation
        obj.GetPersonListCompleted += new EventHandler<GetPersonListCompletedEventArgs>(ListPeople);
        obj.GetPersonListAsync();
		}
