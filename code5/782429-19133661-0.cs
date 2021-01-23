        public Task PlayDemoAsync()
        {
            var completionSource = new TaskCompletionSource<bool>();
            this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    foreach (var ppc in this.Plots.Select(p => this.TransformPlot(p, this.RenderSize)))
                    {
                        // For each subsequent stroke plot, we need to start a new figure.
                        //
                        if (this.Sketch.DrawingPoints.Any())
                            this.Sketch.StartNewFigure(ppc.First().Position);
                        foreach (var point in ppc)
                        {
                            await Task.Delay(100);
                            this.Sketch.DrawingPoints.Add(point.Position);
                        }
                    }
                    completionSource.SetResult(true);
                }
                catch (Exception e)
                {
                    completionSource.SetException(e);
                }
            });
            return (Task)completionSource.Task;
        }
