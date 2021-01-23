      private void LocalSearchCommandExecuted()
            {
                this.loadingElement.Visible = true;
                Task.Factory.StartNew(() =>
                               {
                                   this.SearchCommand.Execute(null);
                               })
                               .ContinueWith(t =>
                               {
                                   if (t.IsCompleted)
                                   {
                                       this.Dispatcher.BeginInvoke((Action)(() => this.loadingElement.Visible= false));
                                       t.Dispose();
                                   }
                               });
            }
