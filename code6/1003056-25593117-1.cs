    public static void MovePlayerToVector(Player player, Vector2 newPos)
    {
        player.pos = newPos;
        UpdateHitboxes(player);
    }
