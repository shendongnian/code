    // The initial destroy gem code
    var gemsToDestroy = new List<Gem>();
    for (int x = 0; x < gems.GetLength(0); x++)
    {
        if (x != i)
        {
            gemsToDestroy.add(gems[x, j]);
        }
        if (x != j)
        {
            gemsToDestroy.add(gems[i, x]);
        }
    }
    // You can change your for loop above to achieve this directly, but this is the idea
    // We are putting them in order of closest first.
    gemsToDestroy = gemsToDestroy.OrderBy(o => o.DistanceFromStar).ToList();
    // Your periodic UPDATE code - This is pseudo code but should convey the general idea
    // I've been very lazy with my use of LINQ here, you should refactor this solution to 
    // to remove as many iterations of the list as possible.
    if (gemsToDestroy.Any() && timer.Ready)
    {
        var closestDistance = gemsToDestroy[0].DistanceFromStar;
        foreach (var gem in gemsToDestroy.Where(gem => gem.DistanceFromStar == closestDistance))
        {
            gem.Destroy();
        }
        // Again you can do this without LINQ, point is I've removed the now destroyed gems from the list
        gemsToDestroy = gemsToDestroy.Where(gem => gem.DistanceFromStar != closestDistance).ToList();
        timer.Reset(); // So that we wait X time before destroying the next set
    }
