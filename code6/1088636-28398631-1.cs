    public static Vector3 FindBlockLoc(Vector3 location)
    {
        var result = Deltashot.Game.objects.Find(v => v.Position == location);
        if (result != null && result.Position != null)
        {
            return result.Position;
        }
        else
        {
            return Vector3.Zero;
        }
    }
