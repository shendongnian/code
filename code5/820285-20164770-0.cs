    public void Unload(Action unloadIt)
    {
        if (explosions.Contains(unloadIt))
            explosions.Remove(unloadIt);
    }
