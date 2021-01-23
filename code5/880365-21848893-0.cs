	private IEnumerable<ViewMap> TestViews
	{
		get
		{
			return projectDataCandidate.ViewMaps
				.Where(vm => !vm.IsNotTestLane)
				.Select(this.GenerateTestView);
		}
	}
	private void Process(ViewMap testView)
	{
		this.SwimLaneViews.Add(testView);
		testView.ItemsOrphaned += OnItemsOrphaned;
	}
