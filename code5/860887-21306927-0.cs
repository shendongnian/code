    System.Windows.Application.Current.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                           // Update UI component here
                            CheckBox.IsChecked = false;
                        });
