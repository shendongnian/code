    DataClassesDataContext dataContext = new DataClassesDataContext();
    ......
    private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
    {
    	dataContext.SubmitChanges();
    }
