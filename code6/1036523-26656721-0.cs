    public static IEnumerable<Position> GetMembersCloserThan(this IEnumerable<Position> positions, double maxDistance)
    {
        List<Position> closePositions = new List<Position>();
        List<Position> testablePositions = positions.ToList();
            
        foreach (Position position in positions)
        {
            // Skip this one, it has already been matched.
            if (closePositions.Contains(position))
                continue;
            bool isClose = false;
            foreach (Position testAgainstPosition in testablePositions)
            {
                if (position == testAgainstPosition)
                    continue;
                if (GetDistance(position, testAgainstPosition) < maxDistance)
                {
                    // Both the position and the tested position pass.
                    closePositions.Add(position);
                    closePositions.Add(testAgainstPosition);
                    isClose = true;
                    break;
                }
            }
            // Don't test against this position in the future, it was already checked.
            if (!isClose)
            {
                testablePositions.Remove(position);
            }
        }
        return closePositions;
    }
