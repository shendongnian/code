    public void SetNewTDStats(bool win = false)
        {
            var score = (TDGameScore) GameScore;
            TDStats.TotalMatches++;
            if (win)
                TDStats.Won++;
            else
                TDStats.Lost++;
            TDStats.TotalKills += score.Kills;
            TDStats.TotalKillAssists += score.KillAssists;
            TDStats.TotalOffense += score.Offense;
            TDStats.TotalOffenseAssists += score.OffenseAssists;
            TDStats.TotalDefense += score.Defense;
            TDStats.TotalDefenseAssists += score.DefenseAssists;
            TDStats.TotalRecovery += score.Recovery;
            TDStats.TotalTouchdowns += score.TDScore;
            TDStats.TotalTouchdownAssists += score.TDAssists;
            GameDatabase.Instance.UpdateTDStats(AccountID, TDStats);
        }
