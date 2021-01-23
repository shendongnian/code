    public class FindTextChangedBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += OnTextChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= OnTextChanged;
            base.OnDetaching();
        }
        private CancellationTokenSource CancellationTokenSource;
        // We're a UI handler, hence async void.
        private async void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            // Assume that this always runs on the UI thread:
            // no thread safety when exchanging the CTS.
            if (this.CancellationTokenSource != null)
            {
                this.CancellationTokenSource.Cancel();
            }
            this.CancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = this.CancellationTokenSource.Token;
            var textBox = (sender as TextBox);
            if (textBox != null)
            {
                try
                {
                    // If your async work completes too quickly,
                    // the dispatcher will be flooded with UI
                    // update requests producing a laggy user
                    // experience. We'll get around that by
                    // introducing a slight delay (throttling)
                    // before going ahead and performing any work.
                    await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
                    // Reduce TaskCanceledExceptions.
                    // This is async void, so we'll just
                    // exit the method instead of throwing.
                    // IMPORTANT: in order to guarantee that async
                    // requests are executed in correct order
                    // and respond to cancellation appropriately,
                    // you need to perform this check after every await.
                    // THIS is the reason we no longer need the Semaphore.
                    if (cancellationToken.IsCancellationRequested) return;
                    // Harvest the object properties within the DataGrid.
                    // We're still on the UI thread, so this is the
                    // right place to do so.
                    IEnumerable<GridProperty> interestingProperties = this
                        .GetInterestingProperties()
                        .ToArray(); // Redundant if GetInterestingProperties returns a
                                    // list, array or similar materialised IEnumerable.
                    // This appears to be CPU-bound, so Task.Run is appropriate.
                    ObservableCollection<object> tempItems = await Task.Run(
                        () => this.ResolveSearchMarkers(interestingProperties, cancellationToken)
                    );
                    // Do not forget this.
                    if (cancellationToken.IsCancellationRequested) return;
                    // We've run to completion meaning that
                    // OnTextChanged has not been called again.
                    // Time to update the UI.
                    MyClass.Instance.SearchMarkers = tempItems;
                }
                catch (OperationCanceledException)
                {
                    // Expected.
                    // Can still be thrown by Task.Delay for example.
                }
                catch (Exception ex)
                {
                    // This is a really, really unexpected exception.
                    // Do what makes sense: log it, invalidate some
                    // state, tear things down if necessary.
                }
            }
        }
        private IEnumerable<GridProperty> GetInterestingProperties()
        {
            // Be sure to return a materialised IEnumerable,
            // i.e. array, list, collection.
            throw new NotImplementedException();
        }
        private ObservableCollection<object> ResolveSearchMarkersAsync(
            IEnumerable<GridProperty> interestingProperties, CancellationToken cancellationToken)
        {
            var tempItems = new ObservableCollection<object>();
            //Do text search on object properties within a DataGrid
            //and populate temporary ObservableCollection with items.
            foreach (var o in interestingProperties)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (ClassPropTextSearch.Match(o, searchValue))
                {
                    tempItems.Add(o);
                }
            }
            return tempItems;
        }
    }
