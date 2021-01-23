    var alarms = events
        .GroupBy(e => e.Id)
        .SelectMany(grp =>
        {
            // Determine light color based on delay between events
            // go black if event arrives that is not stale
            var black = grp
                .Where(ev => (Date.Now - ev.TimeStamp) < TimeSpan.FromSeconds(2))
                .Select(ev => "black");
            // go yellow if no events after 1 second
            var yellow = black
                .Select(b => Observable.Timer(TimeSpan.FromSeconds(1)))
                .SwitchLatest()
                .Select(t => "yellow");
            // go red if no events after 2 seconds
            var red = black
                .Select(b => Observable.Timer(TimeSpan.FromSeconds(2)))
                .SwitchLatest()
                .Select(t => "red");
            
            return Observable
                .Merge(black, yellow, red)
                .Select(color => new { Id = grp.Key, Color = color });
        });
