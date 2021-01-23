	projectDataCandidate.ViewMaps
		.Where(vm => !vm.IsNotTestLane)
		.Select(this.GenerateTestView)
		.ToList()
		.ForEach(testView =>
		{
			this.SwimLaneViews.Add(testView);
			testView.ItemsOrphaned += OnItemsOrphaned;
		});
