	List<Activity> activities = new List<Activity>
	{
		new Activity { ProjectnumberUnformatted = "abc" },
		new Activity { ProjectnumberUnformatted = "def" },
		new Activity { ProjectnumberUnformatted = "abc" },
		new Activity { ProjectnumberUnformatted = "abc" },
		new Activity { ProjectnumberUnformatted = "def" },
		new Activity { ProjectnumberUnformatted = "ghi" },
		new Activity { ProjectnumberUnformatted = "def" },
	};
	Dictionary<string, List<Activity>> activitiesKeyedOnProjectNumber = (
		from activity in activities
		group activity by activity.ProjectnumberUnformatted into grouped
		select new { key = grouped.Key, value = grouped.ToList() }
		).ToDictionary(
			keySelector: x => x.key,
			elementSelector: x => x.value
			);
