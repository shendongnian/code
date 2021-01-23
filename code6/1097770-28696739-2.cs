    DependencyObject container = TasksListView
       .ItemContainerGenerator
       .ContainerFromItem(TasksListView.SelectedItem);
    
    if (container != null)
    {
       ContentPresenter presenter = GetPresenter(container);
       ListView listView = presenter
          .ContentTemplate
          .FindName("TaskParameterListView", presenter) as ListView;
    }
