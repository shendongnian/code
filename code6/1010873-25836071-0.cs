    //-----------------------------------------------------------------------
    // <copyright file="NewTracingDialog.xaml.cs">
    //     Copyright (c) Putta Khunchalee.
    // </copyright>
    // <author>Putta Khunchalee</author>
    //-----------------------------------------------------------------------
    namespace RouterTracer
    {
        using System;
        using System.Windows.Input;
        using Windows.UI.Xaml;
        using Windows.UI.Xaml.Controls;
        /// <summary>
        /// Dialog for gather tracing information from user.
        /// </summary>
        public sealed partial class NewTracingDialog : ContentDialog
        {
            /// <summary>
            /// Used to remove <see cref="OnDataContextCanExecuteChanged(object, EventArgs)"/> before
            /// changing to the new data context.
            /// </summary>
            private ICommand currentDataContext;
            /// <summary>
            /// Initialize a new instance of the <see cref="NewTracingDialog"/> class.
            /// </summary>
            public NewTracingDialog()
            {
                this.InitializeComponent();
                this.DataContextChanged += this.OnDataContextChanged;
            }
            /// <summary>
            /// Invoke when executable flag of data context has changed.
            /// </summary>
            /// <param name="sender">
            /// Data context that executable flag has changed.
            /// </param>
            /// <param name="e">
            /// The empty <see cref="EventArgs"/>.
            /// </param>
            private void OnDataContextCanExecuteChanged(object sender, EventArgs e)
            {
                this.IsPrimaryButtonEnabled = ((ICommand)sender).CanExecute(null);
            }
            /// <summary>
            /// Invoke when data context has been changed.
            /// </summary>
            /// <param name="sender">
            /// The instance of <see cref="NewTracingDialog"/> that data context has changed.
            /// </param>
            /// <param name="args">
            /// Event informations.
            /// </param>
            private void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
            {
                // Get a new data context.
                var command = (ICommand)args.NewValue;
                if (command == null)
                {
                    return;
                }
                // Disable primary button if data context is not executable.
                this.IsPrimaryButtonEnabled = command.CanExecute(null);
                // Subscribe to data context executable changed event.
                if (this.currentDataContext != null)
                {
                    this.currentDataContext.CanExecuteChanged -= this.OnDataContextCanExecuteChanged;
                }
                command.CanExecuteChanged += this.OnDataContextCanExecuteChanged;
                this.currentDataContext = command;
            }
        }
    }
