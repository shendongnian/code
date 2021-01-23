    this.Dispatcher.Invoke(() =>
                {
                    this.Focus();
                    if (!moveFocus)
                        return;
                    this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }), DispatcherPriority.Background, new object[0]);
