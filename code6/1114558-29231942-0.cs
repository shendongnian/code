    Application.Current.MainWindow.Dispatcher.BeginInvoke(new Action( ()=>
     
                {
                    _viewModel.UpdateInterfaceFromAssigningInfo(assigningInfo);
                }));
