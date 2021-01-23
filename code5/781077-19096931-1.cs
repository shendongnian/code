    // Assume 'Step' is 2 here
    // Session A checks first, then Session B
    if (WhiteLabel.Controllers.GlobalVariables.Step < 3)
    {
        // Session A increments first, then Session B
        WhiteLabel.Controllers.GlobalVariables.Step += 1; // value is now 4
    }
