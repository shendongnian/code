    Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            try
              {
                  ProjectsPage projectsPage = (Window.Current.Content as AppShell).AppFrame.Content as ProjectsPage;
                            projectsPage.FetchProjects();
               }
               catch (Exception ex)
                {
                }
        });
