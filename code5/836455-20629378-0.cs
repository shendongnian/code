        private async Task UpdatePackagesCollection()
        {
            IsBusy = true;
            var list = await SearchPackages().ConfigureAwait(false);    
            this.Packages.Clear();
            IsBusy = false;
            foreach (var p in list)
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    Packages.Add(p);
                }, DispatcherPriority.ContextIdle);
            }  
        }
