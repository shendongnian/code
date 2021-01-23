    Observable.Merge(YourCollection.Select(c => c.OnAnyPropertyChanges()))
        .Subscribe((c) =>
        {
            // notified! do whatever you like here
        });
