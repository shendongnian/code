            var doubleClickReady = doubleClicks
                .SelectMany(clickEvents
                    .Buffer(interClickInterval)
                    .FirstAsync(b => b.Count == 0));
            doubleClickReady
                .Subscribe(e => Console.WriteLine("Now accepting double click!"));
