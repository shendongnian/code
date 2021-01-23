    public interface IDialogManager
    {
        /// <summary>
        /// Show a dialog that performs as Task with generic return type. 
        /// </summary>
        /// <typeparam name="TResult">The result to be returned from the dialog task.</typeparam>
        /// <param name="viewModel">The DialogViewModel type to be displayed.</param>
        /// <returns>The Task to be awaited.</returns>
        Task<TResult> ShowDialog<TResult>(DialogViewModel<TResult> viewModel);
        /// <summary>
        /// Show a dialog that performs as Task.
        /// </summary>
        /// <param name="viewModel">The result to be returned from the dialog task.</param>
        /// <returns>The Task to be awaited.</returns>
        Task ShowDialog(DialogViewModel viewModel);
    }
    
