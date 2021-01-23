    public void onMouseUp(int xPosition, List<List<int>> walls, List<List<int>> positions)
    {
        for (int i = 0; i < walls.Count; i++)
        {
            int[] mapData = mapController.getMapData(i, walls, positions);
            int column = mapData[0];
            int row = mapData[1];
            int right = mapData[2];
            int bottom = mapData[3];
            if (xPosition == column * mapController.map.squareSize)
            {
                mapController.map.cellWalls[i][0] = 1;
            }
        }
    }
