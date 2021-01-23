    public static async void ShowModal(Func<IProgress<string>, Task> workAsync, string title = null, TimeSpan? waitTimeDialogShow = null)
    {
        if (!waitTimeDialogShow.HasValue)
        {
            waitTimeDialogShow = TimeSpan.FromMilliseconds(300);
        }
        var progressWindow = new ProgressWindow();
        progressWindow.Owner = Application.Current.MainWindow;
        var viewModel = progressWindow.DataContext as ProgressWindowViewModel;
        Progress<string> progress = new Progress<string>(text => viewModel.Text = text);
        if(!string.IsNullOrEmpty(title))
        {
            viewModel.Title = title;
        }
        var workingTask = workAsync(progress);
        progressWindow.Loaded += async (s, e) =>
        {
            await workingTask;
            progressWindow.Close();
        };
        await Task.Delay((int)waitTimeDialogShow.Value.TotalMilliseconds);
        if (!workingTask.IsCompleted && !workingTask.IsFaulted)
        {
            progressWindow.ShowDialog();
        }
    }
