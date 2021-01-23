    public static Block CreateBlock(BlockType type, Vector3 position)
    {
        switch (BlockType type)
        {
        case BlockType.Grass:
            return new GrassBlock(position);
        case BlockType.Water:
            return new WaterBlock(position);
        default:
            throw new InvalidOperationException();
        }
    }
