            IObservable<MouseEventArgs> moves =
                controls
                    .Select(c =>
                        Observable
                            .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                                h => c.MouseMove += h,
                                h => c.MouseMove -= h))
                    .Merge()
                    .Select(x => x.EventArgs);
            IObservable<MouseEventArgs> downs =
                controls
                    .Select(c =>
                        Observable
                            .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                                h => c.MouseDown += h,
                                h => c.MouseDown -= h))
                    .Merge()
                    .Select(x => x.EventArgs);
            IObservable<MouseEventArgs> ups =
                controls
                    .Select(c =>
                        Observable
                            .FromEventPattern<MouseEventHandler, MouseEventArgs>(
                                h => c.MouseUp += h,
                                h => c.MouseUp -= h))
                    .Merge()
                    .Select(x => x.EventArgs);
