    private void OnPreviewHandEnter(object sender, HandInputEventArgs args)
    {
        if (this.trackedHandHovers.FirstOrDefault(t => t.Hand.Equals(args.Hand)) == null)
        {
            // additional logic removed for answer sanity
            var timer = new HandHoverTimer(DispatcherPriority.Normal, this.Dispatcher);
            timer.Hand = args.Hand;
            timer.Interval = TimeSpan.FromMilliseconds(Settings.Default.SelectionTime);
            timer.Tick += (o, s) => { this.InvokeHoverClick(args.Hand); };
            this.trackedHandHovers.Add(timer);
            timer.Start();
        }
        args.Handled = true;
    }
