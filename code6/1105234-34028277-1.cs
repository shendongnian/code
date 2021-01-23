    this.PropertyChanged += (s, e) => 
    {
        switch (e.PropertyName)
        {
            case "NameWorking":
            case "FactionWorking":
            case "PointsLimitWorking":
            case "IsValidTeamWorking":
                AddStrikeTeamCommand.RaiseCanExecuteChanged();
                break;
        }
    }
