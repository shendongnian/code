	public List<ScheduleBlock> CombineAllSchedules(List<Schedule> origschedules, out int added)
	{
		added = 0;
		var schedules = new List<ScheduleBlock>();
		foreach (var s in origschedules) {
			var snew = new ScheduleBlock { Schedules = new List<Schedule> { s }, Start = s.Start, End = s.End, Minutes = s.Minutes };
			schedules.Add(snew);
		}
		
		for (var i = 0; i < schedules.Count; i++) {
			var s = schedules[i];
			var matchstart = schedules.Where (s2 => s2.End == s.Start).ToList();
			var matchend = schedules.Where (s2 => s2.Start == s.End).ToList();
			foreach (var s2 in matchstart) {
				var newschedule = CombineSchedules(s2, s);
				if (!schedules.Any (sc => sc.Start == newschedule.Start && sc.End == newschedule.End)) {
					schedules.Add(newschedule);
					added++;
				}
			}
			
			foreach (var s2 in matchend) {
				var newschedule = CombineSchedules(s, s2);
				if (!schedules.Any (sc => sc.Start == newschedule.Start && sc.End == newschedule.End)) {
					schedules.Add(newschedule);
					added++;
				}
			}
		}
		return schedules;
	}
	public ScheduleBlock CombineSchedules(Schedule s1, Schedule s2)
	{
		var schedules = new List<Schedule>();
		if (s1 is ScheduleBlock) schedules.AddRange(((ScheduleBlock)s1).Schedules);
		else schedules.Add(s1);
		if (s2 is ScheduleBlock) schedules.AddRange(((ScheduleBlock)s2).Schedules);
		else schedules.Add(s2);
		var s = new ScheduleBlock {
			Schedules = schedules,
			Start = s1.Start, End = s2.End, Minutes = s1.Minutes + s2.Minutes
		};
		return s;
	}
