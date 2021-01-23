	public virtual ActionResult Index() {
		return View(StatusBoard().OrderBy(s => s.Status));
	}
	private IEnumerable<DefensiveSituationBoardMember> StatusBoard() {
		DateTime now = DateTime.UtcNow;
		DateTime historicalCutoff = now.AddDays(-1);
		IEnumerable<Member> activeMembers = Context.Members.Where(n => !n.Disabled).ToList();
		// IncomingAttack and Reinforcements both implement IDefensiveActivity
		IEnumerable<IncomingAttack> harm = Context.IncomingAttacks.Where(n => n.IsOngoingThreat || n.ArrivalOn > historicalCutoff).ToList();
		IEnumerable<Reinforcements> help = Context.Reinforcements.Where(n => !n.Returned.HasValue || n.Returned > historicalCutoff).ToList();
		// Here's the relevant fix
		IEnumerable<IDefensiveActivity> visibleActivity = help.Union<IDefensiveActivity>(harm);
		return from member in activeMembers
			join harmEntry in harm on member equals harmEntry.DestinationMember into harmGroup
			join activityEntry in visibleActivity on member equals activityEntry.DestinationMember into activityGroup
			select new DefensiveSituationBoardMember {
				Member = member,
				Posture = harmGroup.Max(i => (DefensivePostures?)i.Posture),
				Activity = activityGroup.OrderBy(a => a.ArrivalOn)
			};
	}
