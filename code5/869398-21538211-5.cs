    foreach (var thing in thingsToCheck)
    {
        foreach (var inspectable in thing.GetStuffForInspection())
        {
            var inspected = inspector.Inspect(inspectable.Value);
            if (inspected != inspectable.Value)
            {
                validationResults.Add(new ...);
                if (additionalOp)
                {
                    inspectable.Taste();
                }
            }
        }
    }
