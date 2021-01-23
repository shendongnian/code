    private void add_task()
    {
      NewTaskWindow w = new NewTaskWindow();
      var taskViewModel = ( NewTaskViewModel )w.DataContext;
      var title = taskViewModel.Title;
      var content = taskViewModel.Content;
      w.Show();
    }
