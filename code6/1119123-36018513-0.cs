      #region Progress Ring Start
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Waiter.Visibility = Visibility.Visible; // Progress ring name is Waiter.
                });
                #endregion
                await Task.Delay(1000);
                CheckNav(sender); // Your process
                #region Progress Ring Finish
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Waiter.Visibility = Visibility.Collapsed; // Progress ring name is Waiter.
          
                });
                #endregion
