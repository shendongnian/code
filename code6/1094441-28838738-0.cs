    public void GetAllTBMatches(Action<TurnBasedMatch, TurnBasedMatch.MatchTurnStatus> callback)
    {
        mTurnBasedManager.GetAllTurnbasedMatches(allMatches =>
        {
            foreach (var match in allMatches.MatchesMyTurn())
            {
                var converted = match.AsTurnBasedMatch(mNativeClient.GetUserId());
                Logger.d("MY turn : Passing converted match to user callback:" + converted);
                callback(converted, TurnBasedMatch.MatchTurnStatus.MyTurn);
            }
            foreach (var match in allMatches.MatchesTheirTurn())
            {
                var converted = match.AsTurnBasedMatch(mNativeClient.GetUserId());
                Logger.d("Their Turn : Passing converted match to user callback:" + converted);
                callback(converted, TurnBasedMatch.MatchTurnStatus.TheirTurn);
            }
            foreach (var match in allMatches.MatchesCompleted())
            {
                var converted = match.AsTurnBasedMatch(mNativeClient.GetUserId());
                Logger.d("Completed : Passing converted match to user callback:" + converted);
                callback(converted, TurnBasedMatch.MatchTurnStatus.Complete);
            }
            callback(null, TurnBasedMatch.MatchTurnStatus.Unknown);
        });
    }
    public void GetAllTBInvitations(Action<Invitation> callback)
    {
        mTurnBasedManager.GetAllTurnbasedMatches(allMatches =>
        {
            foreach (var invitation in allMatches.Invitations())
            {
                var converted = invitation.AsInvitation();
                Logger.d("Passing converted invitation to user callback:" + converted);
                callback(converted);
            }
        
            callback(null);
        });
    }
