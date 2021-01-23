    var objects = projectDataCandidate.ViewMaps
        .Where(vm => !vm.IsNotTestLane)
        .Select(this.GenerateTestView)
        .ToList();
    objects.ForEach(a => SwimLaneViews.Add(a));
    objects.ForEach(a => a.ItemsOrphaned += OnItemsOrphaned);
