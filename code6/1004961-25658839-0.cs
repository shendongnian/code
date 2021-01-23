    public static IEnumerable<Vector2> ConvertVectors(float[,] list)
    {
        for (int row = 0; row < list.GetLength(0); row++)
        {
            yield return new Vector2(list[row, 0], list[row, 1]);
        }
    }
