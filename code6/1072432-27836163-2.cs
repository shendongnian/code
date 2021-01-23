    var challengeIDs = userChallenges.Select(c => c.ChallengeId).Distinct();
	var steps = await db.Steps.Where(s => challengeIDs.Contains(s.ChallengeId))
		.ToListAsync()
		.ConfigureAwait(false);
	var stepIDs = steps.Select(s => s.StepId).Distinct();
	var blocks = await db.StepBlocks.Where(b => stepIDs.Contains(b.StepId))
		.ToListAsync()
		.ConfigureAwait(false);
    foreach (var challenge in userChallenges)
    {
        challenge.TotalPossibleCoins = challenge.CoinsWhenCompleted;
		challenge.TotalPossiblePoints = challenge.PointsWhenCompleted;
        var challengeSteps = steps.Where(s => s.ChallengeId == challenge.ChallengeId).ToList();
        var stepBlocks = stepBlocks.Where(b => challengeSteps
            .Any(c => c.StepId == b.StepId))
            .ToList();
        
        challenge.TotalPossibleCoins += challengeSteps.Sum(c => c.CoinsWhenCompleted);
        challenge.TotalPossiblePoints += challengeSteps.Sum(c => c.PointsWhenCompleted);
        challenge.TotalPossibleCoins += stepBlocks.Sum(c => c.CoinsWhenCompleted);
        challenge.TotalPossiblePoints += stepBlocks.Sum(c => c.PointsWhenCompleted);
    }
