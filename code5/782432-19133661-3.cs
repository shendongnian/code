        /// <summary>
        /// Begins a demonstration drawing of the asterism.
        /// </summary>
        public async Task PlayDemoAsync()
        {
            if (this.Sketch != null)
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
            }
        }
