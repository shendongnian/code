    public void MovePlayerToVector(Vector2 newPos)
    {
        pos = newPos;
        UpdateHitboxes(this);
    }
