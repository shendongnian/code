    /// <summary>
    /// The DialogManager that can be used to show Views as Metro modal dialogs.
    /// Import IDialogManager to any view model that needs to show a metro message 
    /// box.
    /// </summary>
    [Export(typeof(IDialogManager))]
    public class DialogManager : IDialogManager
    {
        /// <summary>
        /// Show the required dialog.
        /// </summary>
        /// <param name="viewModel">The view model ascociated with the view.</param>
        public async Task ShowDialog(DialogViewModel viewModel)
        {
            // Locate the ascociated view.
            var viewType = ViewLocator.LocateTypeForModelType(viewModel.GetType(), null, null);
            var dialog = (BaseMetroDialog)Activator.CreateInstance(viewType);
            if (dialog == null)
            {
                throw new InvalidOperationException(
                    String.Format("The view {0} belonging to view model {1} " +
                                      "does not inherit from {2}",
                                      viewType,
                                      viewModel.GetType(),
                                      typeof(BaseMetroDialog)));
            }
            dialog.DataContext = viewModel;
            // Show the metro window.
            MetroWindow firstMetroWindow = 
                Application.Current.Windows.OfType<MetroWindow>().First();
            await firstMetroWindow.ShowMetroDialogAsync(dialog);
            await viewModel.Task;
            await firstMetroWindow.HideMetroDialogAsync(dialog);
        }
        /// <summary>
        /// Show the required dialog.
        /// </summary>
        /// <typeparam name="TResult">The type of result to return.</typeparam>
        /// <param name="viewModel">The view model ascociated with the view.</param>
        public async Task<TResult> ShowDialog<TResult>(DialogViewModel<TResult> viewModel)
        {
            // Locate the ascociated view.
            var viewType = ViewLocator.LocateTypeForModelType(viewModel.GetType(), null, null);
            var dialog = (BaseMetroDialog)Activator.CreateInstance(viewType);
            if (dialog == null)
            {
                throw new InvalidOperationException(
                    String.Format("The view {0} belonging to view model {1} " +
                                      "does not inherit from {2}",
                                      viewType,
                                      viewModel.GetType(),
                                      typeof(BaseMetroDialog)));
            }
            dialog.DataContext = viewModel;
            // Show the metro window.
            MetroWindow firstMetroWindow = Application.Current.Windows.OfType<MetroWindow>().First();
            await firstMetroWindow.ShowMetroDialogAsync(dialog);
            TResult result = await viewModel.Task;
            await firstMetroWindow.HideMetroDialogAsync(dialog);
            return result;
        }
    }
    
