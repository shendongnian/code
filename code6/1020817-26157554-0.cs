        public int SelectedDocumentIndex{ get { return p_SelectedDocumentIndex; }
            set {
                // Store the current value so that we can 
                // change it back if needed.
                var origValue = p_SelectedDocumentIndex;
                // If the value hasn't changed, don't do anything.
                if (value == p_SelectedDocumentIndex)
                    return;
                // Note that we actually change the value for now.
                // This is necessary because WPF seems to query the 
                //  value after the change. The combo box
                // likes to know that the value did change.
                p_SelectedDocumentIndex = value;
                if (tabsCollection.Count() > 1 && CanSave() == true)
                {
                    if (!dm.ShowMessage1(ServiceContainer.GetService<DevExpress.Mvvm.IDialogService>("confirmYesNo")))
                    {
                        Debug.WriteLine("Selection Cancelled.");
                        // change the value back, but do so after the 
                        // UI has finished it's current context operation.
                        Application.Current.Dispatcher.BeginInvoke(
                                new Action(() =>
                                {
                                    Debug.WriteLine("Dispatcher BeginInvoke " + "Setting CurrentPersonCancellable.");
                                    // Do this against the underlying value so 
                                    //  that we don't invoke the cancellation question again.
                                    p_SelectedDocumentIndex = origValue;
                                    DocumentPanel p = tabsCollection.ElementAt(p_SelectedDocumentIndex);
                                    p.IsActive = true;
                                    base.RaisePropertiesChanged("SelectedDocumentIndex");
                                }),
                                System.Windows.Threading.DispatcherPriority.ContextIdle,
                                null
                            );
                        // Exit early. 
                        return;
                    }
                }
                // Normal path. Selection applied. 
                // Raise PropertyChanged on the field.
                Debug.WriteLine("Selection applied.");
                base.RaisePropertiesChanged("SelectedDocumentIndex");
            }
        }
