    // Assume 'Step' is 2 here
    // Session A checks first, then Session B - both checks pass
    if (GlobalVariables.Step < 3)
    {
        // Session A increments first, then Session B
        GlobalVariables.Step += 1; // value is now 4
    }
