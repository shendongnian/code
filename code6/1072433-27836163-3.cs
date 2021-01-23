    var challengeIDs = userChallenges.Select(c => c.ChallengeId).Distinct();
	var steps = await db.Steps.Where(s => challengeIDs.Contains(s.ChallengeId))
		.ToListAsync()
		.ConfigureAwait(false);
	var stepIDs = steps.Select(s => s.StepId).Distinct();
	var blocks = await db.StepBlocks.Where(b => stepIDs.Contains(b.StepId))
		.ToListAsync()
		.ConfigureAwait(false);
