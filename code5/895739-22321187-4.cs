    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    
    namespace Wpf_22297935
    {
        public partial class MainWindow : Window
        {
            // by noseartio - http://stackoverflow.com/q/22297935/1768303
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            EventHandler ProcessClosePopup = delegate { };
    
            private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                this.ProcessClosePopup(this, EventArgs.Empty);
            }
    
            // show two popups with modal-like UI flow
            private async void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                await ShowPopup(this.firstPopup);
                await ShowPopup(this.secondPopup);
            }
    
            private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = true;
            }
    
            // helpers
    
            async Task ShowPopup(Popup popup)
            {
                var tcs = new TaskCompletionSource<bool>();
    
                EventHandler handler = (s, e) => tcs.TrySetResult(true);
                this.ProcessClosePopup += handler;
    
                try
                {
                    EnableControls(false);
    
                    popup.IsEnabled = true;
                    popup.IsOpen = true;
    
                    await tcs.Task;
                }
                finally
                {
                    EnableControls(true);
    
                    popup.IsOpen = false;
                    popup.IsEnabled = false;
    
                    this.ProcessClosePopup -= handler;
                }
            }
    
            void EnableControls(bool enable)
            {
                // assume the root is a Panel control
                var rootPanel = (Panel)this.Content;
    
                foreach (var item in rootPanel.Children.Cast<UIElement>())
                    item.IsEnabled = enable;
            }
        }
    }
